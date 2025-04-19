-- Table: User
CREATE TABLE User (
    UserID SERIAL PRIMARY KEY,
    Role VARCHAR(50) NOT NULL,
    Username VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    PhoneNumber VARCHAR(15)
);

-- Table: Patient
CREATE TABLE Patient (
    PatientID SERIAL PRIMARY KEY,
    UserID INT NOT NULL,
    FullName VARCHAR(100) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender VARCHAR(10) NOT NULL,
    IDNumber VARCHAR(20) UNIQUE NOT NULL,
    FOREIGN KEY (UserID) REFERENCES User(UserID)
);

-- Table: Appointment
CREATE TABLE Appointment (
    AppointmentID SERIAL PRIMARY KEY,
    PatientID INT NOT NULL,
    ProviderID INT NOT NULL,
    DateTime TIMESTAMP NOT NULL,
    Reason TEXT NOT NULL,
    Status VARCHAR(50) NOT NULL,
    FOREIGN KEY (PatientID) REFERENCES Patient(PatientID),
    FOREIGN KEY (ProviderID) REFERENCES Provider(ProviderID)
);

-- Table: HealthStats
CREATE TABLE HealthStats (
    StatID SERIAL PRIMARY KEY,
    PatientID INT NOT NULL,
    DataType VARCHAR(50) NOT NULL,
    Value VARCHAR(255) NOT NULL,
    Timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (PatientID) REFERENCES Patient(PatientID)
);
CREATE TABLE Provider (
    ProviderID SERIAL PRIMARY KEY,
    UserID INT NOT NULL,
    LicenseNumber VARCHAR(50) UNIQUE NOT NULL,
    Specialty VARCHAR(100) NOT NULL,
    FOREIGN KEY (UserID) REFERENCES User(UserID)
);

-- Table: Staff
CREATE TABLE Staff (
    StaffID SERIAL PRIMARY KEY,
    UserID INT NOT NULL,
    ProviderID INT,
    Department VARCHAR(100) NOT NULL,
    Gender VARCHAR(10) NOT NULL,
    IDNumber VARCHAR(20) UNIQUE NOT NULL,
    FOREIGN KEY (UserID) REFERENCES User(UserID),
    FOREIGN KEY (ProviderID) REFERENCES Provider(ProviderID)
);


-- Table: GlobalHealthStats
CREATE TABLE GlobalHealthStats (
    StatID SERIAL PRIMARY KEY,
    Region VARCHAR(100) NOT NULL,
    DataType VARCHAR(50) NOT NULL,
    Value VARCHAR(255) NOT NULL,
    TimeStamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Table: SymptomsLog
CREATE TABLE SymptomsLog (
    LogID SERIAL PRIMARY KEY,
    PatientID INT NOT NULL,
    Symptoms TEXT NOT NULL,
    AIResponse TEXT,
    DateTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (PatientID) REFERENCES Patient(PatientID)
);