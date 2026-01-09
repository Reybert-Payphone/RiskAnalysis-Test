-- ============================================
-- RiskScore API - Database
-- ============================================

CREATE DATABASE RiskAnalysisDB
GO

USE RiskAnalysisDB
GO

-- Tabla RiskAnalysis
CREATE TABLE RiskAnalysis (
    [Id]                  BIGINT IDENTITY(1,1) NOT NULL,
    [Name]                NVARCHAR(100)        NOT NULL,
    [DocumentIdentity]    NVARCHAR(50)         NOT NULL,
    [Amount]              DECIMAL(18,2)        NOT NULL,
    [Score]               INT                  NOT NULL,
    [Status]              INT                  NOT NULL,
    
    CONSTRAINT PK_RiskAnalysis PRIMARY KEY (Id)
);

-- Índice para búsquedas por documento
CREATE INDEX IX_RiskAnalysis_DocumentIdentity 
    ON RiskAnalysis (DocumentIdentity);
