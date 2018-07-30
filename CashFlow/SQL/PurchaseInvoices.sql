select year(DocDate) as "Any"
, ROW_NUMBER() over( partition by year(DocDate) order by DocDate asc) AS "ID"
, DocDate AS "Data"
, NumAtCard AS "Núm. Factura" 
, Concept AS "Detall"
, LicTradNum AS "NIF"
, Import AS "Import"
from PurchaseInvoices
where 1 = 1 
order by DocDate ASC
