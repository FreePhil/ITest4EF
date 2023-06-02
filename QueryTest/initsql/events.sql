create table events
(
    id      bigint auto_increment
        primary key,
    name    varchar(255)             null,
    created datetime default (now()) null
);

INSERT INTO events (id, name, created) VALUES (1, 'event1', '2023-06-02 05:50:14');
