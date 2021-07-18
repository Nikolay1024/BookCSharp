USE AutoLot;

DELETE FROM Inventory;
DELETE FROM Customers;
DELETE FROM Orders;
DELETE FROM CreditRisks;

INSERT Customers VALUES
('Dave', 'Brenner'),
('Matt', 'Walton'),
('Steve', 'Hagen'),
('Pat', 'Walton');

INSERT Inventory VALUES
('VW', 'Black', 'Zippy'),
('Ford', 'Rust', 'Rusty'),
('Saab', 'Black', 'Mel'),
('Yugo', 'Yellow', 'Cluncker'),
('BMW', 'Black', 'Bimmer'),
('BMW', 'Green', 'Hank'),
('BMW', 'Pink', 'Pinky');

INSERT Orders VALUES
(1, 5),
(2, 1),
(3, 4),
(4, 7);