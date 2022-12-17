-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema pokemonmemoryrank
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema pokemonmemoryrank
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `pokemonmemoryrank` DEFAULT CHARACTER SET utf8 ;
USE `pokemonmemoryrank` ;

-- -----------------------------------------------------
-- Table `pokemonmemoryrank`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `pokemonmemoryrank`.`users` (
  `id_user` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(60) NOT NULL,
  PRIMARY KEY (`id_user`),
  UNIQUE INDEX `idUser_UNIQUE` (`id_user` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `pokemonmemoryrank`.`user_scores`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `pokemonmemoryrank`.`user_scores` (
  `id_score` INT NOT NULL AUTO_INCREMENT,
  `id_user` INT NOT NULL,
  `time` TIME(3) NOT NULL,
  `score` INT NOT NULL,
  `difficult` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`id_score`),
  UNIQUE INDEX `idUserScores_UNIQUE` (`id_score` ASC) VISIBLE,
  INDEX `fk_userScores_user_idx` (`id_user` ASC) VISIBLE,
  CONSTRAINT `fk_userScores_user`
    FOREIGN KEY (`id_user`)
    REFERENCES `pokemonmemoryrank`.`users` (`id_user`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `pokemonmemoryrank`.`easy_rank`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `pokemonmemoryrank`.`easy_rank` (
  `id_easy_rank` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(60) NOT NULL,
  `best_time` TIME(3) NOT NULL,
  `best_score` INT NOT NULL,
  PRIMARY KEY (`id_easy_rank`),
  UNIQUE INDEX `idEasyRank_UNIQUE` (`id_easy_rank` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `pokemonmemoryrank`.`normal_rank`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `pokemonmemoryrank`.`normal_rank` (
  `id_normal_rank` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(60) NOT NULL,
  `best_time` TIME(3) NOT NULL,
  `best_score` INT NOT NULL,
  PRIMARY KEY (`id_normal_rank`),
  UNIQUE INDEX `idNormalRank_UNIQUE` (`id_normal_rank` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `pokemonmemoryrank`.`hard_rank`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `pokemonmemoryrank`.`hard_rank` (
  `id_hard_rank` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(60) NOT NULL,
  `best_time` TIME(3) NOT NULL,
  `best_score` INT NOT NULL,
  PRIMARY KEY (`id_hard_rank`),
  UNIQUE INDEX `idHardRank_UNIQUE` (`id_hard_rank` ASC) VISIBLE)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
