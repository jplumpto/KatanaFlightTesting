#include "KatanaSensors.h"
#include <AP_HAL.h>

extern const AP_HAL::HAL& hal;

#define CS_IMU_ADDRESS 0x05
#define RP_IMU_ADDRESS 0x06

KatanaSensors::KatanaSensors(bool connect)
{
	_stick_xacc = 0;
	_stick_yacc = 0;
	_stick_zacc = 0;
	_stick_xgyro = 0;
	_stick_ygyro = 0;
	_stick_zgyro = 0;
	_stick_xmag = 0;
	_stick_ymag = 0;
	_stick_zmag = 0;
	_rudder_xacc = 0;
	_rudder_yacc = 0;
	_rudder_zacc = 0;
	_rudder_xgyro = 0;
	_rudder_ygyro = 0;
	_rudder_zgyro = 0;
	_rudder_xmag = 0;
	_rudder_ymag = 0;
	_rudder_zmag = 0;
	_stick_pot1 = 0;
	_stick_pot2 = 0;
	_rudder_pot = 0;

	nbstruct = sizeof(IMUDataStructure);
}

void KatanaSensors::init(AP_HAL::AnalogIn* analogin)
{
	stick_pot1_pin = analogin->channel(3);
	stick_pot1_pin->set_pin(3);

	stick_pot2_pin = analogin->channel(4);
	stick_pot2_pin->set_pin(4);

	rudder_pot_pin = analogin->channel(5);
	rudder_pot_pin->set_pin(5);

	//hal.i2c->begin();

}

	
bool KatanaSensors::update()
{
	update_string_pots();
	//update_imus();
	return false;
}

void KatanaSensors::update_string_pots()
{
	_stick_pot1 = stick_pot1_pin->read_latest();
	_stick_pot2 = stick_pot2_pin->read_latest();
	_rudder_pot = rudder_pot_pin->read_latest();
}

void KatanaSensors::update_imus()
{
	int i = 0;
	IMUDataStructure * imu_data;
	uint8_t dataCSRx[nbstruct];
	uint8_t dataRPRx[nbstruct];

	/*
		Need to switch to using I2C driver instead of Wire
	*/
        int stat = hal.i2c->read((uint8_t)CS_IMU_ADDRESS,nbstruct,dataCSRx);
	if(stat !=0)
        {
            imu_data = (IMUDataStructure*)dataCSRx;
            _stick_xacc++;
            _stick_yacc = stat;
            _stick_zacc = imu_data->zAcc;
            _stick_xgyro = imu_data->xGyro;
            _stick_ygyro = imu_data->yGyro;
            _stick_zgyro = imu_data->zGyro;
            _stick_xmag = imu_data->xMag;
            _stick_ymag = imu_data->yMag;
            _stick_zmag = imu_data->zMag;
            return;
        }
	//hal.i2c->read(RP_IMU_ADDRESS,nbstruct,dataRPRx);

	//Wire.requestFrom(CS_IMU_ADDRESS,nbstruct); //Request struct from CS_IMU

	//while (0 < Wire.available())
	//{
	//	if (i < nbstruct)
	//	{
	//		dataCSRx[i] = Wire.read();
	//	} else
	//	{
	//		Wire.read();
	//	}
	//	i++;
	//}

	//Request from Rudder Pedal then assign struct while waiting
	//Wire.requestFrom(RP_IMU_ADDRESS,nbstruct); //Request struct from RP_IMU
	
	imu_data = (IMUDataStructure*)dataCSRx;

	_stick_xacc = imu_data->xAcc;
	_stick_yacc = imu_data->yAcc;
	_stick_zacc = imu_data->zAcc;
	_stick_xgyro = imu_data->xGyro;
	_stick_ygyro = imu_data->yGyro;
	_stick_zgyro = imu_data->zGyro;
	_stick_xmag = imu_data->xMag;
	_stick_ymag = imu_data->yMag;
	_stick_zmag = imu_data->zMag;
	
	//Receive Rudder Pedal data
	/*i = 0;

	while (0 < Wire.available())
	{
		if (i < nbstruct)
		{
			dataRPRx[i] = Wire.read();
		} else
		{
			Wire.read();
		}
		i++;
	}*/

	imu_data = (IMUDataStructure*)dataRPRx;

	_rudder_xacc = imu_data->xAcc;
	_rudder_yacc = imu_data->yAcc;
	_rudder_zacc = imu_data->zAcc;
	_rudder_xgyro = imu_data->xGyro;
	_rudder_ygyro = imu_data->yGyro;
	_rudder_zgyro = imu_data->zGyro;
	_rudder_xmag = imu_data->xMag;
	_rudder_ymag = imu_data->yMag;
	_rudder_zmag = imu_data->zMag;
}

void KatanaSensors::set_rudder_IMU_data(uint8_t *data)
{
        IMUDataStructure * imu_data;
        imu_data = (IMUDataStructure*)data;

	_rudder_xacc = imu_data->xAcc;
	_rudder_yacc = imu_data->yAcc;
	_rudder_zacc = imu_data->zAcc;
	_rudder_xgyro = imu_data->xGyro;
	_rudder_ygyro = imu_data->yGyro;
	_rudder_zgyro = imu_data->zGyro;
	_rudder_xmag = imu_data->xMag;
	_rudder_ymag = imu_data->yMag;
	_rudder_zmag = imu_data->zMag;
}

void KatanaSensors::set_stick_IMU_data(uint8_t *data)
{
        IMUDataStructure * imu_data;
        imu_data = (IMUDataStructure*)data;

	_stick_xacc = imu_data->xAcc;
	_stick_yacc = imu_data->yAcc;
	_stick_zacc = imu_data->zAcc;
	_stick_xgyro = imu_data->xGyro;
	_stick_ygyro = imu_data->yGyro;
	_stick_zgyro = imu_data->zGyro;
	_stick_xmag = imu_data->xMag;
	_stick_ymag = imu_data->yMag;
	_stick_zmag = imu_data->zMag;
}
