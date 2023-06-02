create table ones
(
    id      bigint auto_increment
        primary key,
    message varchar(255) null
);

INSERT INTO ones (id, message) VALUES (1, 'message 1');
INSERT INTO ones (id, message) VALUES (2, 'message 2');
