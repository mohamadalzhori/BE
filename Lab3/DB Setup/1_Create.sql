create database librarydb;


create table Authors(
    author_id serial primary key,
    name varchar(50) not null,
    birth_date date not null,
    country varchar(50) not null
);

create table Books(
    book_id serial primary key,
    title varchar(256) not null,
    author_id integer references Authors(author_id),
    isbn varchar(50) not null,
    published_year integer not null,
    quantity integer not null
);

create table borrowers (
    borrower_id serial primary key,
    name varchar(50) not null,
    email varchar(50) not null,
    phone varchar(50) not null
);

create table loans (
    loan_id serial primary key,
    book_id integer references Books(book_id),
    borrower_id integer references borrowers(borrower_id),
    loan_date date not null,
    return_date date not null,
    returned boolean not null default false
);