package dataAccess.repository;

import dataAccess.dbmodel.BookDto;

import java.util.List;

/**
 * Created by Alex on 07/03/2017.
 * Adapted by Andrei 16/06/2018.
 */
public class BookRepositoryCacheDecorator implements IBookRepository {


    private IBookRepository decoratedRepository;
    private Cache<BookDto> cache;

    public BookRepositoryCacheDecorator(IBookRepository bookRepository) {
        this.decoratedRepository = bookRepository;
        this.cache = new Cache<BookDto>();
    }

    public List<BookDto> findAll() {
        if (cache.hasResult()) {
            return cache.load();
        }
        List<BookDto> books = decoratedRepository.findAll();
        cache.save(books);
        return books;
    }

    public BookDto findById(Long id) {
        if (cache.hasResult()) {
            return cache.load().stream().filter(x-> x.getId() == id).findFirst().get();
        }
        return decoratedRepository.findById(id);
    }

    public boolean create(BookDto book) {
        cache.invalidateCache();
        return decoratedRepository.create(book);
    }

    public void update(BookDto book) {
        cache.invalidateCache();
        decoratedRepository.update(book);
    }
}
