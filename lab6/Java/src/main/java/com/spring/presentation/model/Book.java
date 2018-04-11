package com.spring.presentation.model;

import javax.persistence.*;
import java.util.Date;

/**
 * @author Nicoleta GHITESCU at 27-Mar-18
 */

@Entity
@Table(name = "books")
public class Book {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(name = "BOOK_UID")
    private Long bookUid;

    @Column(name = "TITLE")
    private String title;

    @Column(name = "AUTHOR")
    private String author;

    public Book() {
    }

    public Book(String title, String author) {
        this.title = title;
        this.author = author;
    }

    public Long getBookUid() {
        return bookUid;
    }

    public void setBookUid(Long bookUid) {
        this.bookUid = bookUid;
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
        return "Book{" +
                "bookUid=" + bookUid +
                ", title='" + title + '\'' +
                ", author='" + author + '\'' +
                '}';
    }


}
