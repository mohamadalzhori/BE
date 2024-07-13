
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