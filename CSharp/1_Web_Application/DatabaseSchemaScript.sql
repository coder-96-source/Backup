CREATE DATABASE MyArticles;

USE MyArticles
--TOPIC Table
CREATE TABLE Topic
(
TopicID int NOT NULL PRIMARY KEY,
Name nvarchar(20) NOT NULL,
Picture varbinary(max),
PictureMimeType varchar(50)
);
--Article Table
CREATE TABLE Article
(
ArticleID int NOT NULL PRIMARY KEY,
TopicID int FOREIGN KEY REFERENCES Topic(TopicID),
Title nvarchar(100) NOT NULL,
Content nvarchar(max) NOT NULL,
PostTime datetime NOT NULL,
ShowFlag bit NOT NULL
);
CREATE INDEX AIndex
ON Article (TopicID)

--Comment Table
CREATE TABLE Comment
(
CommentID int NOT NULL PRIMARY KEY,
ArticleID int,
Content nvarchar(max) NOT NULL,
CommentPassword nvarchar(128) NOT NULL,
PostTime datetime NOT NULL,
);
CREATE INDEX CIndex
ON Comment (ArticleID)

ALTER TABLE Comment
ADD CONSTRAINT FK_Article_Comment_CAS
FOREIGN KEY (ArticleID) REFERENCES Article(ArticleID) ON DELETE CASCADE
--Keyword Table
CREATE TABLE Keyword
(
KeywordID int NOT NULL PRIMARY KEY,
ArticleID int,
Content nvarchar(100)
);
CREATE INDEX KIndex
ON Keyword (ArticleID)

ALTER TABLE Keyword
ADD CONSTRAINT FK_Article_Keyword_CAS
FOREIGN KEY (ArticleID) REFERENCES Article(ArticleID) ON DELETE CASCADE
--Account Table
CREATE TABLE Account
(
AccountID int NOT NULL PRIMARY KEY,
Name nvarchar(20) NOT NULL,
AccountPassword nvarchar(128) NOT NULL
)