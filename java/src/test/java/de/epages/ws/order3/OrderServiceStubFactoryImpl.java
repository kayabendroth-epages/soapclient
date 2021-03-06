package de.epages.ws.order3;

import javax.xml.rpc.ServiceException;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import de.epages.ws.StubConfigurator;
import de.epages.ws.WebServiceConfiguration;
import de.epages.ws.order3.stub.Bind_Order_SOAPStub;
import de.epages.ws.order3.stub.OrderService;
import de.epages.ws.order3.stub.Port_Order;

final class OrderServiceStubFactoryImpl implements OrderServiceStubFactory {

    private static final Logger log = LoggerFactory.getLogger(OrderServiceStubFactoryImpl.class);

    @Override
    public Port_Order create(WebServiceConfiguration config, OrderService service) {
        log.info("Using webservice URL: " + config.getWebserviceURL());
        try {
            Bind_Order_SOAPStub stub = (Bind_Order_SOAPStub) service.getport_Order(config.getWebserviceURL());
            if (stub == null) {
                throw new NullPointerException("stub");
            }
            return StubConfigurator.configure(stub, config);
        } catch (ServiceException e) {
            throw new RuntimeException(e);
        }
    }

}
