-- =============================================
-- Author:		Pablo Paez
-- Create date: 22/10/2020
-- Description:	Metodo que valida ingreso de una llave y registra el acceso
-- =============================================
CREATE PROCEDURE [dbo].[validarIngreso] @cadenaQr varchar(50), @idEdificio int

AS
BEGIN
	Declare
		@fechayHoraCaducacion datetime,
		@desechable bit,
		@habilitada bit

	select @fechayHoraCaducacion = fechayHoraCaducacion,@desechable = desechable , @habilitada = habilitada
	from Llaves
	where cadenaQr = @cadenaQr and idEdificio = @idEdificio


	if (@fechayHoraCaducacion is not NULL and @fechayHoraCaducacion > GETDATE() and @habilitada = 1 and @desechable = 1)
	begin
		insert into LlavesActivadas (cadenaQr, fechayHoraActivacion) values (@cadenaQr, GETDATE())
		return 1
	end
	
	else
	begin
		if (@fechayHoraCaducacion is not NULL and @fechayHoraCaducacion > GETDATE() and @habilitada = 1)
		begin
			insert into LlavesActivadas (cadenaQr, fechayHoraActivacion) values (@cadenaQr, GETDATE())
			return 1
		end
		else
		begin
			return 0
		end
	end

END
