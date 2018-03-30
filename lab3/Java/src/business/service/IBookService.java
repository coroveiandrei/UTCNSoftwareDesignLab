package business.service;

import business.model.BookModel;

import java.util.List;


/**
 * Created by Alex on 07/03/2017.
 * Adapted by Andrei 16/06/2018.
 */
public interface IBookService {

    List<BookModel> findAll();

    BookModel findById(Long id);

    boolean create(BookModel book);

    int getAgeOfBook(Long id);

}
