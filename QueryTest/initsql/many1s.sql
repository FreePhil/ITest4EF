create table many1s
(
    id       bigint auto_increment
        primary key,
    updated  datetime default (now()) null,
    created  datetime default (now()) null,
    event_id bigint                   null,
    one_id   bigint                   null
);

INSERT INTO many1s (id, updated, created, event_id, one_id) VALUES (1, '2023-05-02 05:51:08', '2023-05-02 05:51:08', 1, 1);
INSERT INTO many1s (id, updated, created, event_id, one_id) VALUES (2, '2023-06-02 05:51:08', '2023-06-02 05:51:08', 1, 2);
