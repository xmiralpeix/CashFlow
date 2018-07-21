/****** Script for SelectTopNRows command from SSMS  ******/
DECLARE @IPC as decimal = 2.30

SELECT O.Name
	, Concept
	, ToDate	
	, CAST( (IncomeImport / AssetsImport) * 100 as decimal(3,2)) - (@IPC /12) AS MonthlyInvestmentIndex
	, (CAST( (IncomeImport / AssetsImport) * 100 as decimal(3,2)) * 12) - @IPC AS YearlyInvestmentIndex
	
  FROM [CashFlowEntries] C WITH (NOLOCK)
  INNER JOIN Owners O WITH (NOLOCK) ON  O.ID = c.Owner_ID
  where 1 = 1 
  AND COALESCE(ToDate, GETDATE() + 1) >= GETDATE()
  AND "Status" = 0
  AND "IncomeImport" > 0
  AND "AssetsImport" > 0

