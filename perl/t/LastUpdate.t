use strict;
use Test::More tests => 17;
use WebServiceClient;
use WebServiceConfiguration qw( WEBSERVICE_URL WEBSERVICE_USER );

# Create a SOAP::Lite client object
my $UpdateService = WebServiceClient
    ->uri( 'urn://epages.de/WebService/UpdateService/2014/06' )
    ->proxy( WEBSERVICE_URL )
    ->userinfo( WEBSERVICE_USER )
    ->xmlschema('2001');

my $ProductService = WebServiceClient
    ->uri( 'urn://epages.de/WebService/ProductService/2013/01' )
    ->proxy( WEBSERVICE_URL )
    ->userinfo( WEBSERVICE_USER )
    ->xmlschema('2001');

sub createTestProducts {
   my @Aliases = @_;
   foreach my $Alias (@Aliases) {
       $ProductService->create([{
           Alias => $Alias,
           Name  => [{
             LanguageCode => 'de',
             'Value' => SOAP::Data->type('string')->value("TestProduct $Alias")
           }],
           StockLevel => 1,
           ProductPrices => [{CurrencyID => 'EUR', Price => 1, TaxModel => 'gross', }],
       }]);
   }
}

sub updateStockLevel {
   my @Aliases = @_;
   foreach my $Alias (@Aliases) {
       $ProductService->update([{
           Path => "Products/$Alias",
           StockLevel => 2,
       }]);
   }
}

sub updateListPrice {
   my @Aliases = @_;
   foreach my $Alias (@Aliases) {
       $ProductService->update([{
           Path => "Products/$Alias",
           ProductPrices => [{CurrencyID=>'EUR',Price=>2,TaxModel=>'gross'}],
       }]);
   }
}

sub updateContent {
   my @Aliases = @_;
   foreach my $Alias (@Aliases) {
       $ProductService->update([{
           Path => "Products/$Alias",
           Name  => [{
             LanguageCode => 'de',
             'Value' => SOAP::Data->type('string')->value("TestProduct $Alias updated")
           }],
       }]);
   }
}

sub removeTestProducts {
   my @Aliases = @_;
   foreach my $Alias (@Aliases) {
       $ProductService->delete(["Products/$Alias"]);
   }
}

# run test suite
use Data::Dumper;

my @TestProducts = qw(Alias-01 Alias-02 Alias-03);
createTestProducts(@TestProducts);      #create some test products

#get last sync time
my $response = $UpdateService->findUpdates('2013-04-14T03:44:55', 'Product', 'Content');
ok( !$response->fault, 'findUpdates Content called to get sync date' );
my $LastSync = $response->result->{LatestUpdate};

#get content updates after last sync
$response = $UpdateService->findUpdates( $LastSync, 'Product', 'Content');
ok( !$response->fault, 'findUpdates Content called to check sync date' );
ok( 0 == @{$response->result->{Updates}}, 'no Content updates jet');

#get stock level updates after last sync
$response = $UpdateService->findUpdates( $LastSync, 'Product', 'StockLevel');
ok( !$response->fault, 'findUpdates StockLevel called to check sync date' );
ok( 0 == @{$response->result->{Updates}}, 'no StockLevel updates jet');

#get price updates after last sync
$response = $UpdateService->findUpdates( $LastSync, 'Product', 'ListPrice');
ok( !$response->fault, 'findUpdates ListPrice called to check sync date' );
ok( 0 == @{$response->result->{Updates}}, 'no ListPrice updates jet');

#get deletes after last sync
$response = $UpdateService->findDeletes( $LastSync, 'Product' );
ok( !$response->fault, 'findDeletes called' );
ok( 0 == @{$response->result}, 'no deletes jet');

sleep(1);

#update content of first test product
updateContent($TestProducts[0]);
$response = $UpdateService->findUpdates($LastSync, 'Product', 'Content');
ok( !$response->fault, 'findUpdates Content called' );
ok( 1 == @{$response->result->{Updates}}, '1 Content update');

#update stock level of next test product
updateStockLevel($TestProducts[1]);
$response = $UpdateService->findUpdates($LastSync, 'Product', 'StockLevel');
ok( !$response->fault, 'findUpdates StockLevel called' );
ok( 1 == @{$response->result->{Updates}}, '1 StockLevel update');

#update price of last test product
updateListPrice($TestProducts[2]);
$response = $UpdateService->findUpdates($LastSync, 'Product', 'ListPrice');
ok( !$response->fault, 'findUpdates ListPrice called' );
ok( 1 == @{$response->result->{Updates}}, '1 ListPrice update');

#remove
removeTestProducts(@TestProducts);
$response = $UpdateService->findDeletes( $LastSync, 'Product' );
ok( !$response->fault, 'findDeletes called' );
ok( 3 == @{$response->result}, '3 deletes now');


