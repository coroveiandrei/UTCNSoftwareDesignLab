package dataAccess.repository;

import dataAccess.dbmodel.BookDto;
import sun.reflect.generics.reflectiveObjects.NotImplementedException;
import utility.JDBConnectionWrapper;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Alex on 07/03/2017.
 * Adapted by Andrei 16/06/2018.
 */
public class BookRepositoryMySQL implements IBookRepository {

    private final JDBConnectionWrapper connectionWrapper;

    public BookRepositoryMySQL(JDBConnectionWrapper connectionWrapper) {
        this.connectionWrapper = connectionWrapper;
    }

    public List<BookDto> findAll() {
        Connection connection = connectionWrapper.getConnection();
        List<BookDto> books = new ArrayList<BookDto>();
        try {
            Statement statement = connection.createStatement();
            String sql = "Select * from book";
            ResultSet rs = statement.executeQuery(sql);

            while (rs.next()) {
                books.add(getBookFromResultSet(rs));
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

        return books;
    }

    public BookDto findById(Long id) {
        throw new NotImplementedException();
    }

    public void update(BookDto book) {

    }

    public boolean create(BookDto book) {
        throw new NotImplementedException();
    }

    private BookDto getBookFromResultSet(ResultSet rs) throws SQLException {
        BookDto book = new BookDto();
        book.setId(rs.getLong("id"));
        return book;
    }
}