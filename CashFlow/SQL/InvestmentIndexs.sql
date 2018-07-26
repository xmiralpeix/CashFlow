/****** Script for SelectTopNRows command from SSMS  ******/

WITH TIPC AS (
	SELECT COALESCE(MAX(Value), 0) AS IPC FROM IPCs WHERE COALESCE(ToDate, CAST(GETDATE() + 1 AS DATE)) >=  CAST(GETDATE() AS DATE)
)
, TSQL AS (
SELECT O.Name
	, Concept
	, ToDate	
	, CAST( (IncomeImport / AssetsImport) * 100 as decimal(3,2)) AS "MIndex"
	
	
  FROM [CashFlowEntries] C WITH (NOLOCK)
  INNER JOIN Owners O WITH (NOLOCK) ON  O.ID = c.Owner_ID
  where 1 = 1 
  AND COALESCE(ToDate, GETDATE() + 1) >= GETDATE()
  AND "Status" = 0
  AND "IncomeImport" > 0
  AND "AssetsImport" > 0 )

SELECT Name
	, Concept
	, ToDate	
	, "MIndex" - (TIPC.IPC / 12) AS "MonthlyIndex"
	, ("MIndex" * 12) - TIPC.IPC  AS "YearlyIndex"
	FROM TSQL
	INNER JOIN TIPC ON 1 = 1

