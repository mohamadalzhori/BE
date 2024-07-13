
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