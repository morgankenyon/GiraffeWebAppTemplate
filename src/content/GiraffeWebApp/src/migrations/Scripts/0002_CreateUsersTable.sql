CREATE TABLE db_schema.users (
	user_id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	first_name TEXT NOT NULL,
	last_name TEXT NOT NULL,
	email TEXT NOT NULL UNIQUE,
	hashed_password TEXT NOT NULL,
	salt TEXT NOT NULL
);