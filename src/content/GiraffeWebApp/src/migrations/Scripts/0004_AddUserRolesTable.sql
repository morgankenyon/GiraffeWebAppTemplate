CREATE TABLE db_schema.user_roles (
    user_id INTEGER NOT NULL,
    role_id INTEGER NOT NULL,
	created_at TIMESTAMPTZ DEFAULT (timezone('utc', now())),
    PRIMARY KEY (user_id, role_id),
    FOREIGN KEY (user_id) REFERENCES db_schema.users(user_id),
    FOREIGN KEY (role_id) REFERENCES db_schema.roles(role_id)
);