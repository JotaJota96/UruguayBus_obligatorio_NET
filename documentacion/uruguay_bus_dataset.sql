
--
-- Vaciado de todas las tablas
--
BEGIN TRAN t;
    DELETE FROM parametro
    DELETE FROM pasaje;
    DELETE FROM paso_por_parada;
    DELETE FROM viaje;
    DELETE FROM horario;
    DELETE FROM precio;
    DELETE FROM tramo;
    DELETE FROM parada;
    DELETE FROM linea;
    DELETE FROM vehiculo;
    DELETE FROM superadmin;
    DELETE FROM conductor;
    DELETE FROM admin;
    DELETE FROM usuario;
    DELETE FROM persona;
COMMIT TRAN t;

--
-- Reinicio de contadores para ID incrementales
--
BEGIN TRAN t;
    DBCC CHECKIDENT ('pasaje', RESEED, 1);
    DBCC CHECKIDENT ('viaje', RESEED, 1);
    DBCC CHECKIDENT ('horario', RESEED, 1);
    DBCC CHECKIDENT ('precio', RESEED, 1);
    DBCC CHECKIDENT ('parada', RESEED, 1);
    DBCC CHECKIDENT ('linea', RESEED, 1);
    DBCC CHECKIDENT ('vehiculo', RESEED, 1);
    DBCC CHECKIDENT ('persona', RESEED, 1);
COMMIT TRAN t;

--
-- tablINTO *********************************************************
--a persona
INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Luis', 'Garsia', 'LuisGarcia@gmail.com', '1234', 1, '58745487');
INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Federico', 'Perez', 'fperez@gmail.com', '1234', 1, '57986532');
INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Belen', 'Curbelo', 'BeluCur@gmail.com', '1234', 1, '37879887');
INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Juan', 'Rodriguez', 'LuC31@gmail.com', '1234', 2, 'A1458');
INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Rodrigo', 'Guitierres', 'GuRodrigo@gmail.com', '1234', 1, '25468795');
INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Florencia', 'Noguera', 'FNog@gmail.com', '1234', 1, '58635474');
INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Christian', 'Perez', 'CHPerez@gmail.com', '1234', 1, '58635474');
INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Agustina', 'Diaz', 'AguDiaz2010@gmail.com', '1234', 1, '58635474');
INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Lucia', 'Perez', 'LuPerez@gmail.com', '1234', 2, 'B1587');
INSERT INTO persona (nombre, apellido, correo, contrasenia, tipo_documento, documento) VALUES ('Karen', 'Garcia', 'KGarcia@gmail.com', '1234', 1, '58635474');

-- contrasenia '1234' para todos los usuarios
UPDATE persona SET contrasenia = 'vGbuG8B2/xmmTRAxOyMiE35kGOkGtHR2sPn43Na1dl8=';

--
-- tablINTO *********************************************************
--a usuario
INSERT INTO usuario (id)
	SELECT id FROM persona

--
-- **** tabla admin *********************************************************
--
INSERT INTO admin (id) VALUES (4);
INSERT INTO admin (id) VALUES (5);

--
-- **** tabla conductor *********************************************************
--
INSERT INTO conductor (id, vencimiento_libreta) VALUES (6, '2029-07-02');
INSERT INTO conductor (id, vencimiento_libreta) VALUES (7, '2015-05-06');
INSERT INTO conductor (id, vencimiento_libreta) VALUES (8, '2030-01-15');
INSERT INTO conductor (id, vencimiento_libreta) VALUES (9, '2026-01-25');

--
-- **** tabla superadmin *********************************************************
--
INSERT INTO superadmin (id) VALUES (10);

--
-- **** tabla vehiculo *********************************************************
--
INSERT INTO vehiculo (matricula, marca, modelo, cant_asientos, latitud, longitud) VALUES ('MAB 5024', 'Mercedes', '1318', 25,NULL,NULL);
INSERT INTO vehiculo (matricula, marca, modelo, cant_asientos, latitud, longitud) VALUES ('MBB 3243', 'Volvo', 'B430R', 35,NULL,NULL);
INSERT INTO vehiculo (matricula, marca, modelo, cant_asientos, latitud, longitud) VALUES ('MAF 5344', 'Mercedes', '7 Ma', 30,NULL,NULL);
INSERT INTO vehiculo (matricula, marca, modelo, cant_asientos, latitud, longitud) VALUES ('MDF 6543', 'MARCOPOLO', 'VIAGGIO 1050', 20,NULL,NULL);

--
-- **** tabla linea *********************************************************
--
INSERT INTO linea (nombre) VALUES ('San José - Montevidoe Directo');
INSERT INTO linea (nombre) VALUES ('San José - Montevidoe Semi Directo');
INSERT INTO linea (nombre) VALUES ('San José - Montevidoe Directisimo');
INSERT INTO linea (nombre) VALUES ('San José - Canelones Directo');
INSERT INTO linea (nombre) VALUES ('San José - Canelones Directisimo');

--
-- **** tabla parada *********************************************************
--
INSERT INTO parada (nombre, latitud, longitud) VALUES ('Terminal de Ómnibus San José de Mayo', -34.34006741034748, -56.714420781150324);
INSERT INTO parada (nombre, latitud, longitud) VALUES ('Parada de Rivera San José de Mayo', -34.34546638998191, -56.71956039944203);
INSERT INTO parada (nombre, latitud, longitud) VALUES ('Parada Libertad San José', -34.63780304762206, -56.61987469894831);
INSERT INTO parada (nombre, latitud, longitud) VALUES ('Plaza Cuba Montevideo', -34.8721766, -56.2027395);
INSERT INTO parada (nombre, latitud, longitud) VALUES ('Tres Cruces Montevideo', -34.893951222229404, -56.166246689410954);
INSERT INTO parada (nombre, latitud, longitud) VALUES ('Terminal de Ómnibus Santa Lucía', -34.4550929, -56.3893012);
INSERT INTO parada (nombre, latitud, longitud) VALUES ('Terminal de Ómnibus Canelones',  -34.622248, -55.99038);

--
-- **** tabla tramo *********************************************************
--
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (1,1,1,'00:00:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (2,1,2,'00:05:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (3,1,3,'00:20:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (4,1,4,'00:20:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (5,1,5,'00:10:00')

INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (1,2,1,'00:00:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (3,2,2,'00:35:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (5,2,3,'00:25:00')

INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (1,3,1,'00:00:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (5,3,2,'00:50:00')

INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (1,4,1,'00:00:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (6,4,2,'00:35:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (7,4,3,'00:25:00')

INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (1,5,1,'00:00:00')
INSERT INTO tramo (parada_id,linea_id,numero,tiempo) VALUES (7,5,2,'00:55:00')

--
-- **** tabla precio *********************************************************
--
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (0, '2020-10-09',1,1);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (60, '2020-10-09',2,1);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (50, '2020-06-09',2,1);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (140, '2020-10-19',3,1);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (100, '2020-04-19',3,1);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (230, '2020-10-19',4,1);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (127, '2020-02-01',4,1);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (80, '2020-10-19',5,1);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (60, '2020-04-30',5,1);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (0, '2020-09-10',1,2);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (200, '2020-09-10',3,2);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (150, '2020-05-01',3,2);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (250, '2020-09-10',5,2);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (200, '2020-04-25',5,2);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (0, '2020-10-10',1,3);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (550, '2020-10-10',5,3);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (350, '2020-03-25',5,3);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (0, '2020-09-10',1,4);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (300, '2020-09-10',6,4);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (200, '2020-04-11',6,4);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (250, '2020-09-10',7,4);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (100, '2020-05-25',7,4);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (0, '2020-10-10',1,5);

INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (600, '2020-10-10',7,5);
INSERT INTO precio (valor, fecha_validez, parada_id, linea_id) VALUES (500, '2020-11-13',7,5);
 
--p Horario conductores:6,7,8,9 -Veiculos: 1,2,3,4 -linea: 1,2,3,4,5
--
-- **** tabla horario *********************************************************
--
INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('05:00:00',6,1,1);
INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('09:00:00',6,1,2);
INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('14:00:00',6,1,3);

INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('07:00:00',7,2,4);
INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('10:30:00',7,2,5);

INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('15:00:00',8,3,1);
INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('19:00:00',8,3,2);
INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('20:00:00',8,3,3);

INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('12:00:00',9,4,4);
INSERT INTO horario (hora, conductor_id, vehiculo_id, linea_id) VALUES ('18:00:00',9,4,5);

--
-- **** tabla viaje *********************************************************
--
INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('2020-10-10', 1, 1);
INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('2020-09-11', 0, 2);
INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('2020-10-09', 1, 3);
INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('2020-09-12', 1, 4);
INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('2020-08-14', 1, 5);
INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('2020-10-20', 0, 6);
INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('2020-05-01', 1, 7);
INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('2020-10-10', 1, 8);
INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('2020-08-19', 1, 9);
INSERT INTO viaje (fecha,finalizado,horario_id) VALUES ('2020-11-10', 0, 10);

/*
INSERT INTO viaje (fecha,finalizado,horario_id)
    SELECT f.fecha as 'fecha', null as 'finalizado', h.id as 'horario_id'
    FROM horario h, (
            SELECT '2020-10-28' as 'fecha' union
            SELECT '2020-10-29' as 'fecha' union
            SELECT '2020-10-30' as 'fecha' union
            SELECT '2020-10-03' as 'fecha' union
            SELECT '2020-10-04' as 'fecha' union
            SELECT '2020-10-05' as 'fecha'
        ) f
    WHERE h.linea_id = 1
    
*/

--
-- **** tabla paso_por_parada *********************************************************
--
INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (1, 2, '2020-10-10 05:05:22');
INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (1, 3, '2020-10-10 05:30:58');
INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (1, 4, '2020-10-10 05:45:45');
INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (1, 5, '2020-10-10 06:05:45');

INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (2, 3, '2020-09-11 09:36:48');
INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (2, 5, '2020-09-11 10:03:57');
	
INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (3, 4, '2020-10-09 14:45:05');

INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (4, 3, '2020-09-12 07:36:08');
INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (4, 5, '2020-09-12 07:56:17');
	
INSERT INTO paso_por_parada (viaje_id, parada_id, fecha_hora) VALUES (5, 2, '2020-08-14 11:02:12');

--
-- **** tabla pasaje *********************************************************
--
INSERT INTO pasaje (asiento, usado, tipo_documento, documento, usuario_id, viaje_id, parada_id_origen, parada_id_destino) 
    VALUES (15, 1, NULL, NULL, 1, 2, 1, 5);

INSERT INTO pasaje (asiento, usado, tipo_documento, documento, usuario_id, viaje_id, parada_id_origen, parada_id_destino) 
    VALUES (25, 1, 1,'78459658', NULL, 2, 1, 3);

INSERT INTO pasaje (asiento, usado, tipo_documento, documento, usuario_id, viaje_id, parada_id_origen, parada_id_destino) 
    VALUES (20, 0, NULL, NULL, 2, 6, 2, 5);

INSERT INTO pasaje (asiento, usado, tipo_documento, documento, usuario_id, viaje_id, parada_id_origen, parada_id_destino) 
    VALUES (10, 0, NULL, NULL, 3, 6, 2, 4);

INSERT INTO pasaje (asiento, usado, tipo_documento, documento, usuario_id, viaje_id, parada_id_origen, parada_id_destino) 
    VALUES (13, 0, NULL, NULL, 4, 6, 2, 5);

INSERT INTO pasaje (asiento, usado, tipo_documento, documento, usuario_id, viaje_id, parada_id_origen, parada_id_destino) 
    VALUES (16, 0, NULL, NULL, 5, 6, 3, 5);

