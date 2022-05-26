DROP DATABASE udecamp;
CREATE DATABASE udecamp;

CREATE TABLE career(
    id_career int PRIMARY KEY IDENTITY,
    name_career varchar(50) NOT NULL,
    level_of_education varchar(50) NOT NULL,
    estimated_duration int NOT NULL,
    academic_credits int NOT NULL
);

INSERT INTO career(name_career, level_of_education, estimated_duration, academic_credits) 
VALUES ('Ingeniería de sistemas y computación','Pregrado', 10, 153);

INSERT INTO career(name_career, level_of_education, estimated_duration, academic_credits) 
VALUES ('Ingeniería de sistemas','Pregrado', 10, 156);

INSERT INTO career(name_career, level_of_education, estimated_duration, academic_credits) 
VALUES ('Administración de Empresas','Pregrado', 9, 158);

INSERT INTO career(name_career, level_of_education, estimated_duration, academic_credits) 
VALUES ('Psicología','Pregrado', 9, 154);

CREATE TABLE student(
	cod_st int PRIMARY KEY NOT NULL,
    career_st int NOT NULL,
    nam_st varchar(30) NOT NULL,
    ape_st varchar(30) NOT NULL,
    email_st varchar(100) NOT NULL UNIQUE,
    pass_st varchar(50) NOT NULL,
    conditions_st bit NOT NULL,
    FOREIGN KEY (career_st) REFERENCES career(id_career)
);

INSERT INTO student(cod_st, career_st, nam_st, ape_st, email_st, pass_st, conditions_st) 
VALUES (461220141, 1,'Daniel','Lara', 'ydaniellara@ucundinamarca.edu.co','vivaPetro',1);

INSERT INTO student(cod_st, career_st, nam_st, ape_st, email_st, pass_st, conditions_st) 
VALUES (461551236, 1,'Santiago','Cuervo', 'scuervoq@ucundinamarca.edu.co','vivaPetro',1);

INSERT INTO student(cod_st, career_st, nam_st, ape_st, email_st, pass_st, conditions_st) 
VALUES (46166122, 3,'Edwin','Cardenas', 'eframirez@ucundinamarca.edu.co','Buenardo',1);

INSERT INTO student(cod_st, career_st, nam_st, ape_st, email_st, pass_st, conditions_st) 
VALUES (461220142, 4,'Daniela','Perez', 'danpe@ucundinamarca.edu.co','456',1);

CREATE TABLE type_post(
    id_post int PRIMARY KEY IDENTITY, 
    name_post varchar(50) NOT NULL
);

CREATE TABLE post(
    id_pos int PRIMARY KEY IDENTITY, 
    cod_stu int NOT NULL UNIQUE,
    type_post int NOT NULL,
    text_post varchar(8000) NOT NULL,
    date_post date NOT NULL,
    FOREIGN KEY (cod_stu) REFERENCES student(cod_st) ON DELETE CASCADE,
    FOREIGN KEY (type_post) REFERENCES type_post(id_post)
);

CREATE TABLE comment(
    id_co int PRIMARY KEY IDENTITY, 
    cod_co int NOT NULL UNIQUE,
    text_co varchar(8000) NOT NULL,
    date_co date NOT NULL,
    id_post_co int NOT NULL,
    FOREIGN KEY (cod_co) REFERENCES student(cod_st) ON DELETE CASCADE,
    FOREIGN KEY (id_post_co) REFERENCES post(id_pos) ON DELETE NO ACTION
);

CREATE TABLE type_like(
    id_like int PRIMARY KEY IDENTITY, 
    name_like varchar(50) NOT NULL
);

CREATE TABLE like_po(
    id_like int PRIMARY KEY IDENTITY, 
    cod_stud int NOT NULL UNIQUE,
    type_like int NOT NULL,
    id_po int NOT NULL,
    date_post date NOT NULL,
    FOREIGN KEY (cod_stud) REFERENCES student(cod_st) ON DELETE CASCADE,
    FOREIGN KEY (type_like) REFERENCES type_like(id_like),
    FOREIGN KEY (id_po) REFERENCES post(id_pos) ON DELETE NO ACTION
);