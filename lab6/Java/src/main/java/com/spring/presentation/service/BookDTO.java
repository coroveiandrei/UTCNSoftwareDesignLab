package com.spring.presentation.service;

import java.io.Serializable;

/**
 * @author Nicoleta GHITESCU at 27-Mar-18
 */

public class BookDTO implements Serializable {

    private String title;
    private String author;

    public BookDTO() {
    }

    public BookDTO(String title, String author) {
        this.title = title;
        this.author = author;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getAuthor() {
        return author;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    @Override
    public String toString() {
        return "BookDTO{" +
                "title='" + title + '\'' +
                ", author='" + author + '\'' +
                '}';
    }
}
