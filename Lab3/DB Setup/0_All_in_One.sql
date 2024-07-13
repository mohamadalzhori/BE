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

INSERT INTO Authors (name, birth_date, country) VALUES
    ('Jane Austen', '1775-12-16', 'United Kingdom'),
    ('Fyodor Dostoevsky', '1821-11-11', 'Russia'),
    ('Gabriel García Márquez', '1927-03-06', 'Colombia'),
    ('Haruki Murakami', '1949-01-12', 'Japan'),
    ('J.K. Rowling', '1965-07-31', 'United Kingdom');

INSERT INTO Books (title, author_id, isbn, published_year, quantity) VALUES
    ('Pride and Prejudice', 1, '9780141439518', 1813, 1),
    ('Crime and Punishment', 2, '9780486415871', 1866, 2),
    ('One Hundred Years of Solitude', 3, '9780060883287', 1967, 4),
    ('Norwegian Wood', 4, '9780375704024', 1987, 2),
    ('Harry Potter and the Philosopher''s Stone', 5, '9780590353427', 1997, 5);

INSERT INTO borrowers (name, email, phone) VALUES
    ('Alice Johnson', 'alice@example.com', '+1234567890'),
    ('Bob Smith', 'bob@example.com', '+1987654321'),
    ('Emily Brown', 'emily@example.com', '+1654321897'),
    ('John Doe', 'john@example.com', '+1789456123'),
    ('Sarah Williams', 'sarah@example.com', '+1122334455');

INSERT INTO loans (book_id, borrower_id, loan_date, return_date, returned) VALUES
    (1, 1, '2024-07-12', '2024-08-12', false),
    (2, 2, '2024-07-10', '2024-08-10', false),
    (3, 3, '2024-07-08', '2024-08-08', false),
    (4, 4, '2024-07-06', '2024-08-06', false),
    (5, 5, '2024-07-04', '2024-08-04', false),
    (3, 3, '2024-07-08', '2024-08-08', false),
    (4, 4, '2024-07-06', '2024-08-06', false),
    (5, 5, '2024-07-04', '2024-08-04', false),
    (4, 4, '2024-07-06', '2024-08-06', false),
    (5, 5, '2024-06-04', '2024-07-04', false),
    (5, 5, '2024-06-04', '2024-07-04', false);



    -- Retrieve all books published in a specific year.
select *
from books
where published_year = 1997;

-- List all loans that are overdue (books that haven't been returned by their due date).
select *
from loans
where returned = false and return_date < current_date;

-- Find books borrowed by a specific borrower.

select books.book_id, books.title, books.author_id, books.isbn, books.published_year
from books inner join loans on books.book_id = loans.book_id
where borrower_id = 1;

-- Calculate the total number of books in the library.
select count(*) as nb_of_books
from books;

-- Create a view named Popular Books that lists books with the highest number of loans.
create view popular_books as
select books.title, count(*) nb_loans
from books inner join loans on books.book_id = loans.book_id
group by books.book_id
order by nb_loans desc;

-- use the view
select * from popular_books;

-- borrow function
create function borrow(book_id integer, borrower_id integer)
returns date as $$
declare
    total_quantity integer;
    louns_count integer;
    return_date date;
Begin
    -- get the total quantity of this book from books table

    select books.quantity into total_quantity
    from books
    where books.book_id = borrow.book_id;

    -- count the number of loans for this book that are not returned,
    select count(*) into louns_count
    from loans
    where loans.book_id = borrow.book_id and returned  = false;

    -- if the total quantity is greater than then available for loan
    if total_quantity > louns_count then
        return_date := current_date + interval '1 week';

    -- log the loan
    insert into loans (book_id, borrower_id, loan_date, return_date)
    values (borrow.book_id, borrow.borrower_id, current_date, return_date);

    return return_date;

    else
        return null;
    end if;

end;
$$ LANGUAGE plpgsql;

-- using the borrow function
select  borrow(2,1);

-- return function
CREATE OR REPLACE FUNCTION return_book(loan_id INTEGER)
RETURNS BOOLEAN AS $$
DECLARE
    book_id INTEGER;
    borrower_id INTEGER;
BEGIN
    -- Check if the loan exists and is not already returned
    SELECT loans.book_id, loans.borrower_id INTO book_id, borrower_id
    FROM loans
    WHERE loans.loan_id = return_book.loan_id AND returned = false;

    -- If no such loan exists, raise an exception
    IF NOT FOUND THEN
        RETURN FALSE;
    END IF;

    -- Update the loan to mark it as returned
    UPDATE loans
    SET returned = true, return_date = CURRENT_DATE
    WHERE loans.loan_id = return_book.loan_id;

    RETURN TRUE;
END;
$$ LANGUAGE plpgsql;

-- using the return_book function
select return_book(2);