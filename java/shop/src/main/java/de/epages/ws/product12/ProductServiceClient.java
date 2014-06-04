package de.epages.ws.product12;

import de.epages.ws.product12.model.TCreate_Input;
import de.epages.ws.product12.model.TCreate_Return;
import de.epages.ws.product12.model.TDelete_Return;
import de.epages.ws.product12.model.TExists_Return;
import de.epages.ws.product12.model.TGetInfo_Return;
import de.epages.ws.product12.model.TUpdate_Input;
import de.epages.ws.product12.model.TUpdate_Return;
import de.epages.ws.product12.stub.Port_Product;

public interface ProductServiceClient extends Port_Product {

    /**
     * get information about a list of products
     */
    TGetInfo_Return[] getInfo(String[] products);

    /**
     * get information about a list of products
     */
    TGetInfo_Return[] getInfo(String[] products, String[] attributes);

    /**
     * get information about a list of products
     */
    TGetInfo_Return[] getInfo(String[] products, String[] attributes, String[] languageCodes);

    /**
     * check if a list of products exist.
     */
    TExists_Return[] exists(String[] products);

    /**
     * delete a list of products
     */
    TDelete_Return[] delete(String[] products);

    /**
     * update a list of products
     */
    TUpdate_Return[] update(TUpdate_Input[] products);

    /**
     * create new products
     */
    TCreate_Return[] create(TCreate_Input[] products);

    /**
     * find products
     */
    String[] find(de.epages.ws.product12.stub.TFind_Input searchParameters);

}
