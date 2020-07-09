Create PROCEDURE validarIngresoBeta
(  
      @code VARCHAR(100),  
      @idEdificio Int
)  
AS  
DECLARE @resultado int  
BEGIN TRAN  
IF EXISTS  
    (  
          SELECT * FROM llaves
          WHERE llaves.cadenaQr =  @code AND llaves.idEdificio = @idEdificio
        )  
     BEGIN  
         SET  @resultado = 1  
     END  
ELSE
    BEGIN
     SET @resultado = 0
    END
IF @resultado <> 0 OR @resultado <> 1
     BEGIN  
            ROLLBACK TRAN  
      END  
ELSE  
      BEGIN  
            COMMIT TRAN  
      END  
RETURN @resultado



Declare @resultado int
Execute @resultado = validarIngresoBeta @code = '66lkws8CA7AbVba', @idEdificio = 2;
Select @resultado
