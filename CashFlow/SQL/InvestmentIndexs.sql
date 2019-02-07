WITH TSQL AS (

SELECT O.Name
	, Concept
	, c.FromDate
	, ToDate	
	, CAST( (IncomeImport / AssetsImport) * 100 as decimal(3,2)) AS "MIndex"
	, coalesce((SELECT SUM([Value]) as IPC FROM [IPCs] I where 1 = 1 AND I.FromDate > c.FromDate and I.FromDate <= cast(coalesce(c.ToDate, getdate()) as date)), 0) AS IPC
	
  FROM [CashFlowEntries] C WITH (NOLOCK)
  INNER JOIN Owners O WITH (NOLOCK) ON  O.ID = c.Owner_ID
  where 1 = 1 
  AND COALESCE(ToDate, GETDATE() + 1) >= GETDATE()
  AND "Status" = 0)

SELECT Name as "Propietari"
	, Concept as "Concepte"
	, "MIndex" - (IPC / 12) AS "Índex mensual"
	, ("MIndex" * 12) - IPC  AS "Índex anual"
	, IPC
    , FromDate as "Data inici"	
	, ToDate as "Data fi"	
	FROM TSQL