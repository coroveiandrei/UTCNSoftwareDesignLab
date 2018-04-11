package com.spring.presentation.service;

import com.spring.presentation.model.Book;

import java.util.List;

/**
 * @author Nicoleta GHITESCU at 27-Mar-18
 */

public interface BookService {

    List<Book> getAllBooks();

    Book getBookById(Long bookId);

    Book saveBook(BookDTO bookDTO);

    Book updateBook(Long bookId, BookDTO bookDTO);

    void deleteBookById(Long bookId);
}
