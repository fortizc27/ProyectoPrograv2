DROP TABLE IF EXISTS #PedidoTemp

SELECT 
IdPedido, Cliente INTO #PedidoTemp
FROM (
VALUES
(1, 'Manuel')

)AS TEMP (IdPedido, Cliente)

----ACTUALIZAR DATOS---
UPDATE pe SET
  pe.Cliente= TM.Cliente
FROM dbo.Pedido pe
INNER JOIN #PedidoTemp TM
    ON pe.IdPedido= TM.IdPedido

    ----INSERTAR DATOS---

SET IDENTITY_INSERT dbo.Pedido ON

INSERT INTO dbo.Pedido(
IdPedido, Cliente)
SELECT
IdPedido, Cliente
FROM #PedidoTemp


EXCEPT
SELECT
IdPedido, Cliente
FROM dbo.Pedido


SET IDENTITY_INSERT dbo.Pedido OFF

GO

