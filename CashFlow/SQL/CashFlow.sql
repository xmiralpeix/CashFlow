WITH TCashFlow AS (
	select C.Owner_ID AS "OwnerID"
		, SUM(C.IncomeImport) AS IncomeImport
		, SUM(C.ExpensesImport) AS ExpensesImport
		, SUM(C.AssetsImport) AS AssetsImport
		, SUM(C.LiabilitiesImport) AS LiabilitiesImport
	from CashFlowEntries C	
	where 1 = 1 
	AND CAST(GETDATE() AS DATE) BETWEEN COALESCE(FromDate, CAST(GETDATE() AS DATE)) AND COALESCE(ToDate, CAST(GETDATE() AS DATE))
	AND Status IN (0)
	GROUP BY C.Owner_ID )
-- Product deposits
, TProductDeposits AS (
	SELECT D.ID
	FROM Deposits D
	WHERE D.ID NOT IN (select ProductDeposit_ID from FinancialProducts where Status = 0)
)
-- Balance of deposits
, TOwnerCash AS (

	select d.Owner_ID AS "OwnerID"
		, SUM("Import") AS "Cash"
		
	from JournalEntries JE
	--
	inner join Deposits D 
	ON D.ID = JE.Deposit_ID 
	AND D.ID NOT IN (SELECT ID FROM TProductDeposits)
	AND D.CancelDate IS NULL
	 --
	where 1 = 1 
	AND JE.CancelDate IS NULL
	AND JE.FiscalYear IS NULL
	GROUP BY d.Owner_ID

)


SELECT CF.IncomeImport AS "Ingressos Passius"
	 , CF.ExpensesImport AS "Despeses Passius"
	 , (IncomeImport - ExpensesImport) AS "Diferencia Passius"	 
	 , CF.AssetsImport AS "Actius"
	 , CF.LiabilitiesImport AS "Passius"	 
	 , O.Name AS "Propietari"
	 , COALESCE(OC.Cash, 0) AS "Disponible"
FROM TOwnerCash OC
FULL JOIN TCashFlow CF ON CF.OwnerID = OC.OwnerID
INNER JOIN Owners O ON O.ID = COALESCE(OC.OwnerID, CF.OwnerID)
