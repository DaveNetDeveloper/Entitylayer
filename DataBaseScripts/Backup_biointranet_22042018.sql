-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 22-04-2018 a las 02:11:16
-- Versión del servidor: 10.1.16-MariaDB
-- Versión de PHP: 5.6.24

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `biointranet`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `area`
--

CREATE TABLE `area` (
  `Id` int(11) NOT NULL,
  `Nombre` text,
  `Descripción` text,
  `Responsable` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `area`
--

INSERT INTO `area` (`Id`, `Nombre`, `Descripción`, `Responsable`) VALUES
(1, 'hhhhhhhhhhhhhhhhhhhhh', 'Descripción del area', 'xxxx@biosystems.es'),
(2, 'hhhhhhhhhhhhhhhhhhhhh', 'Descripción del area', 'xxxx@biosystems.es'),
(3, 'hhhhhhhhhhhhhhhhhhhhh', 'Descripción del area', 'xxxx@biosystems.es');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aviso`
--

CREATE TABLE `aviso` (
  `Id` int(11) NOT NULL,
  `Titulo` text,
  `Contenido` text,
  `FechaInicio` datetime DEFAULT NULL,
  `FechaFin` datetime DEFAULT NULL,
  `IdSeccion` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `departamento`
--

CREATE TABLE `departamento` (
  `Id` int(11) NOT NULL,
  `Nombre` text,
  `Descripción` text,
  `Responsable` text,
  `IdArea` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `departamento`
--

INSERT INTO `departamento` (`Id`, `Nombre`, `Descripción`, `Responsable`, `IdArea`) VALUES
(1, 'Personal', 'Departamento de personal', 'rcontreras@biosystems.es', 2),
(2, 'Administración', 'Departamento de administración', 'mcuixart@biosystems.es', 2),
(4, 'Electrónica', 'Departamento de Electrónica', 'rpalazon@biosystems.es', 3),
(5, 'Física', 'Departamento de Física', 'stortosa@biosystems.es', 3),
(8, 'Mecánica', 'Departamento de Mecánica', 'fgrau@biosystems.es', 3),
(9, 'Software', 'Departamento de Software', 'mibanez@biosystems.es', 3),
(10, 'Documentos comité', 'Documentos comité', 'jrosset@niosystems.es', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `documento`
--

CREATE TABLE `documento` (
  `Id` int(11) NOT NULL,
  `Nombre` text,
  `Ubicacion` text,
  `Descripcion` text,
  `Tamaño` bigint(20) DEFAULT NULL,
  `IdSeccion` int(11) DEFAULT NULL,
  `FechaCreacion` datetime DEFAULT NULL,
  `Tipo` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `documento`
--

INSERT INTO `documento` (`Id`, `Nombre`, `Ubicacion`, `Descripcion`, `Tamaño`, `IdSeccion`, `FechaCreacion`, `Tipo`) VALUES
(1, 'Calendario laboral 2018', '~/Documentos/ComiteDeEmpresa/CalendarioLaboral2018.pdf', '...', 100, NULL, '2018-04-02 00:00:00', 'pdf'),
(2, 'Calendario laboral 2017', '~/Documentos/ComiteDeEmpresa/CalendarioLaboral2017.pdf', '...', 90, NULL, '2017-04-02 00:00:00', 'pdf'),
(3, 'Acta reunión 10 de marzo de 2018', '~/Documentos/ComiteDeEmpresa/ActaReunion10032018.docx', '...', 90, NULL, '2017-04-02 00:00:00', 'doc'),
(4, 'Acta reunión 15 de marzo de 2018', '~/Documentos/ComiteDeEmpresa/ActaReunion15032018.docx', '...', 90, NULL, '2017-04-02 00:00:00', 'doc');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `imagen`
--

CREATE TABLE `imagen` (
  `Id` int(11) NOT NULL,
  `Nombre` text,
  `Descripción` text,
  `Ubicacion` text,
  `IdSeccion` int(11) NOT NULL,
  `FechaCreacion` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `noticia`
--

CREATE TABLE `noticia` (
  `Id` int(11) NOT NULL,
  `Titulo` text,
  `Contenido` text,
  `FechaNoticia` date DEFAULT NULL,
  `IdImagen` int(11) NOT NULL,
  `IdDocumento` int(11) NOT NULL,
  `IdSeccion` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `seccion`
--

CREATE TABLE `seccion` (
  `Id` int(11) NOT NULL,
  `Nombre` text,
  `Descripción` text,
  `IdDepartamento` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `area`
--
ALTER TABLE `area`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `aviso`
--
ALTER TABLE `aviso`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `departamento`
--
ALTER TABLE `departamento`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `documento`
--
ALTER TABLE `documento`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `imagen`
--
ALTER TABLE `imagen`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `noticia`
--
ALTER TABLE `noticia`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `seccion`
--
ALTER TABLE `seccion`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `area`
--
ALTER TABLE `area`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT de la tabla `aviso`
--
ALTER TABLE `aviso`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `departamento`
--
ALTER TABLE `departamento`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT de la tabla `documento`
--
ALTER TABLE `documento`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT de la tabla `imagen`
--
ALTER TABLE `imagen`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `noticia`
--
ALTER TABLE `noticia`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `seccion`
--
ALTER TABLE `seccion`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
