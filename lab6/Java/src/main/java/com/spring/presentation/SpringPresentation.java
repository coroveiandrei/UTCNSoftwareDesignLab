package com.spring.presentation;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

/**
 * @author Nicoleta GHITESCU at 27-Mar-18
 */

@SpringBootApplication
public class SpringPresentation {

    /**
     * Deploys the Spring application inside an embedded Tomcat
     *
     * @param args args
     */
    public static void main(String[] args) {
        SpringApplication.run(SpringPresentation.class, args);
    }
}
