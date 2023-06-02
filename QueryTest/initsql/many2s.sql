create table many2s
(
    id       bigint auto_increment
        primary key,
    created  datetime default (now()) null,
    event_id bigint                   null,
    one_id   bigint                   null
);

INSERT INTO many2s (id, created, event_id, one_id) VALUES (1, '2023-05-02 05:52:18', 1, 1);
INSERT INTO many2s (id, created, event_id, one_id) VALUES (2, '2023-06-02 05:52:18', 1, 2);
