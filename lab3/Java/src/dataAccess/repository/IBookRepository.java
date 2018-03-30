package dataAccess.repository;

import dataAccess.dbmodel.BookDto;

import java.util.List;

/**
 * Created by Alex on 07/03/2017.
 * Adapted by Andrei 16/06/2018.
 */
public interface IBookRepository {

    List<BookDto> findAll();

    BookDto findById(Long id);

    boolean create(BookDto book);

    void update(BookDto book);
}
