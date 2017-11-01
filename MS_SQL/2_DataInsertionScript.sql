USE MyShoppingMall

INSERT INTO Customer
VALUES (0, 'Jason Kim', '07/23/1992', '8454806952')
INSERT INTO Customer
VALUES (1, 'Scott Kim', '07/23/1991', '0000000000')
INSERT INTO Customer
VALUES (2, 'Chen Lee', '07/23/1993', '0000000000')
INSERT INTO Customer
VALUES (3, 'DJ Koo', '07/23/1994', '0000000000')
INSERT INTO Customer
VALUES (4, 'Jhon Nam', '07/23/1995', '0000000000')

INSERT INTO Product
VALUES (0, 'Sun Screen', 'Beauty', 30.99, 100)
INSERT INTO Product
VALUES (1, 'Lotion', 'Beauty', 10.99, 100)
INSERT INTO Product
VALUES (2, 'Bread', 'Food', 5.99, 100)
INSERT INTO Product
VALUES (3, 'Water', 'Food', 1.99, 100)
INSERT INTO Product
VALUES (4, 'Meat', 'Food', 9.99, 100)

INSERT INTO PurchaseHistory
VALUES (0, 0, 0, 0, 0)
INSERT INTO PurchaseHistory
VALUES (1, 0, 1, 0, 0)
INSERT INTO PurchaseHistory
VALUES (2, 1, 1, 0, 0)
INSERT INTO PurchaseHistory
VALUES (3, 1, 2, 0, 0)
INSERT INTO PurchaseHistory
VALUES (4, 2, 3, 0, 0)
