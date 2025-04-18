-- �����������
CREATE TABLE organization (
    organization_id INT PRIMARY KEY NOT NULL, 
    name VARCHAR(255) NOT NULL,
    short_name VARCHAR(50),
    address VARCHAR(80) NOT NULL
);
-- ����������
CREATE TABLE employees (
    employee_id INT PRIMARY KEY NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    first_name VARCHAR(50) NOT NULL,
    patronymic VARCHAR(50),
    birth_date DATE NOT NULL,
    address VARCHAR(80) NOT NULL
);

-- �������������
CREATE TABLE departments (
    department_id INT PRIMARY KEY NOT NULL,
    name VARCHAR(100) NOT NULL,
    employee_id INT, FOREIGN KEY (employee_id) REFERENCES employees(employee_id)
);

-- ���������
CREATE TABLE positions (
    position_id INT PRIMARY KEY NOT NULL,
    name VARCHAR(100) NOT NULL,
    employee_id INT, FOREIGN KEY (employee_id) REFERENCES employees(employee_id)
);


-- ������� ����������
CREATE TABLE employee_history (
    history_id INT PRIMARY KEY NOT NULL,
    employee_id INT, FOREIGN KEY (employee_id) REFERENCES employees(employee_id),
    department_id INT, FOREIGN KEY (department_id) REFERENCES departments(department_id),
    position_id INT, FOREIGN KEY (position_id) REFERENCES positions(position_id),
    start_date DATE NOT NULL,
    end_date DATE,
    stavka INT NOT NULL
);

-- ������� ������������
CREATE TABLE schedules (
    schedule_id INT PRIMARY KEY NOT NULL,
    schedule_number VARCHAR(20) NOT NULL,
    obsled_date DATE NOT NULL ,
    department_id INT REFERENCES departments(department_id)
);

CREATE TABLE users
(
users_id DECIMAL(5) NOT NULL PRIMARY KEY,
role VARCHAR(35) NOT NULL, 
pasword VARCHAR(35) NOT NULL
);

INSERT INTO organization (organization_id, name, short_name, address) 
VALUES 
(1, '��� "�������������"', '�������������', '�. ������, ��. ������������, 15');
SELECT * FrOM employee_history;

INSERT INTO departments (department_id, name, employee_id) 
VALUES 
(1, '����� ������', 3),
(2, 'IT-�����', 1),
(3, '���������������� �����', 5);

INSERT INTO positions (position_id, name, employee_id) 
VALUES 
(1, '������������', 3),
(2, '��������', 1),
(3, '��������', 5);

INSERT INTO employees (employee_id, last_name, first_name, patronymic, birth_date, address) 
VALUES 
(1, '������', '����', '���������', '1985-07-15', '�. ������, ��. ������, 25'),
(2, '��������', '�����', '��������', '1990-12-03', '�. ������, ��. ����, 18'),
(3, '��������', '�������', '����������', '1978-04-22', '�. ������, ��. �������, 7'),
(4, '�������', '�����', '����������', '1995-09-14', '�. ������, ��. �����������, 33'),
(5, '�������', '�������', '���������', '1982-11-30', '�. ������, ��. ���������, 12');

INSERT INTO employee_history (history_id, employee_id, department_id, position_id, start_date, end_date, stavka) 
VALUES 
(1, 1, 2, 1, '2020-01-10', NULL, 1.0),
(2, 2, 2, 2, '2021-05-15', NULL, 1.0),
(3, 3, 1, 3, '2015-03-01', NULL, 1.0),
(4, 4, 3, 2, '2022-08-20', '2023-12-31', 0.75),
(5, 5, 3, 1, '2018-06-10', NULL, 1.0);


INSERT INTO schedules (schedule_id, schedule_number, obsled_date, department_id) 
VALUES 
(1, '����-2024-IT', '2024-01-20', 2),
(2, '����-2024-������', '2024-01-22', 3);