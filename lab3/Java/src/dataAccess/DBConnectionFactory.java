package dataAccess;

import utility.JDBConnectionWrapper;


/**
 * Created by Alex on 07/03/2017.
 * Adapted by Andrei 16/06/2018.
 */
public class DBConnectionFactory {

    public JDBConnectionWrapper getConnectionWrapper(boolean test) {
        if (test) {
            return new JDBConnectionWrapper("test_library");
        }
        return new JDBConnectionWrapper("library");
    }

}
