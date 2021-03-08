package business.service;

import dataAccess.dbmodel.BookDto;
import business.model.BookModel;
import dataAccess.repository.BookRepositoryCacheDecorator;
import dataAccess.repository.BookRepositoryMySQL;
import dataAccess.repository.IBookRepository;
import utility.JDBConnectionWrapper;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

/**
 * Created by Alex on 07/03/2017.
 * Adapted by Andrei 16/06/2018.
 */
public class BookServiceImpl implements IBookService {

    private final IBookRepository repository;

    public BookServiceImpl() {
        this.repository = new BookRepositoryCacheDecorator(new BookRepositoryMySQL(new JDBConnectionWrapper("dbo")));
    }

    @Override
    public List<BookModel> findAll() {
        List<BookDto> list = repository.findAll();
        List<BookModel> result = new ArrayList<BookModel>();
        for (BookDto t:list) {
            // map between Dto and Model
            result.add(new BookModel());
        }
        return result;
    }

    @Override
    public BookModel findById(Long id) {

        return null;
        //return dataAccess.repository.findById(id);
    }

    @Override
    public boolean create(BookModel book) {
        return false;
    }

    @Override
    public int getAgeOfBook(Long id) {
        BookModel book = findById(id);
        Date publishedDate = book.getPublishedDate();

        Calendar calendar = Calendar.getInstance();
        calendar.setTime(publishedDate);
        int yearOfPublishing = calendar.get(Calendar.YEAR);
        calendar.setTime(new Date());
        int yearToday = calendar.get(Calendar.YEAR);

        return yearToday - yearOfPublishing;
    }
}
