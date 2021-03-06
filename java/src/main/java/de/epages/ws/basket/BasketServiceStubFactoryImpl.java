package de.epages.ws.basket;

import javax.xml.rpc.ServiceException;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import de.epages.ws.StubConfigurator;
import de.epages.ws.WebServiceConfiguration;
import de.epages.ws.basket.stub.BasketService;
import de.epages.ws.basket.stub.Bind_Basket_SOAPStub;
import de.epages.ws.basket.stub.Port_Basket;

final class BasketServiceStubFactoryImpl implements BasketServiceStubFactory {

    private static final Logger log = LoggerFactory.getLogger(BasketServiceStubFactoryImpl.class);

    @Override
    public Port_Basket create(WebServiceConfiguration config, BasketService service) {
        log.info("Using webservice URL: " + config.getWebserviceURL());
        try {
            Bind_Basket_SOAPStub stub = (Bind_Basket_SOAPStub) service.getport_Basket(config.getWebserviceURL());
            if (stub == null) {
                throw new NullPointerException("stub");
            }
            return StubConfigurator.configure(stub, config);
        } catch (ServiceException e) {
            throw new RuntimeException(e);
        }
    }

}
