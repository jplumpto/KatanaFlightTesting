#ifndef KATANA_SENSORS_H
#define KATANA_SENSORS_H

#include "Arduino.h"
#include <stdint.h>
#include "AnalogIn.h"

class KatanaSensors
{
public:
	KatanaSensors(bool connect);
	
	void init(AP_HAL::AnalogIn* analogin);
	bool update();
	int16_t stick_xacc(){ return	_stick_xacc;	}	 ///< X acceleration (raw)
	int16_t stick_yacc(){ return	_stick_yacc;	}	 ///< Y acceleration (raw)
	int16_t stick_zacc(){ return	_stick_zacc;	}	 ///< Z acceleration (raw)
	int16_t stick_xgyro(){ return	_stick_xgyro;	}	 ///< Angular speed around X axis (raw)
	int16_t stick_ygyro(){ return	_stick_ygyro;	}	 ///< Angular speed around Y axis (raw)
	int16_t stick_zgyro(){ return	_stick_zgyro;	}	 ///< Angular speed around Z axis (raw)
	int16_t stick_xmag(){ return	_stick_xmag;	}	 ///< X Magnetic field (raw)
	int16_t stick_ymag(){ return	_stick_ymag;	}	 ///< Y Magnetic field (raw)
	int16_t stick_zmag(){ return	_stick_zmag;	}	 ///< Z Magnetic field (raw)
	int16_t rudder_xacc(){ return	_rudder_xacc;	}	 ///< X acceleration (raw)
	int16_t rudder_yacc(){ return	_rudder_yacc;	}	 ///< Y acceleration (raw)
	int16_t rudder_zacc(){ return	_rudder_zacc;	}	 ///< Z acceleration (raw)
	int16_t rudder_xgyro(){ return	_rudder_xgyro;	}	 ///< Angular speed around X axis (raw)
	int16_t rudder_ygyro(){ return	_rudder_ygyro;	}	 ///< Angular speed around Y axis (raw)
	int16_t rudder_zgyro(){ return	_rudder_zgyro;	}	 ///< Angular speed around Z axis (raw)
	int16_t rudder_xmag(){ return	_rudder_xmag;	}	 ///< X Magnetic field (raw)
	int16_t rudder_ymag(){ return	_rudder_ymag;	}	 ///< Y Magnetic field (raw)
	int16_t rudder_zmag(){ return	_rudder_zmag;	}	 ///< Z Magnetic field (raw)
	int16_t stick_pot1(){ return	_stick_pot1;	}	 ///< Stick deflection pot 1 (raw)
	int16_t stick_pot2(){ return	_stick_pot2;	}	 ///< Stick deflection pot 2 (raw)
	int16_t rudder_pot(){ return	_rudder_pot;	}	 ///< Rudder deflection pot (raw)

        void set_rudder_IMU_data(uint8_t *data);
        void set_stick_IMU_data(uint8_t *data);
private:
	struct IMUDataStructure{
		//Gyros
		int xGyro;
		int yGyro;
		int zGyro;

		//Accels
		int xAcc;
		int yAcc;
		int zAcc;

		//Mag
		int xMag;
		int yMag;
		int zMag;
	}; //IMUDataStructure

	int nbstruct;

	AP_HAL::AnalogSource * stick_pot1_pin;
	AP_HAL::AnalogSource * stick_pot2_pin;
	AP_HAL::AnalogSource * rudder_pot_pin;

	int16_t _stick_xacc; ///< X acceleration (raw)
	int16_t _stick_yacc; ///< Y acceleration (raw)
	int16_t _stick_zacc; ///< Z acceleration (raw)
	int16_t _stick_xgyro; ///< Angular speed around X axis (raw)
	int16_t _stick_ygyro; ///< Angular speed around Y axis (raw)
	int16_t _stick_zgyro; ///< Angular speed around Z axis (raw)
	int16_t _stick_xmag; ///< X Magnetic field (raw)
	int16_t _stick_ymag; ///< Y Magnetic field (raw)
	int16_t _stick_zmag; ///< Z Magnetic field (raw)
	int16_t _rudder_xacc; ///< X acceleration (raw)
	int16_t _rudder_yacc; ///< Y acceleration (raw)
	int16_t _rudder_zacc; ///< Z acceleration (raw)
	int16_t _rudder_xgyro; ///< Angular speed around X axis (raw)
	int16_t _rudder_ygyro; ///< Angular speed around Y axis (raw)
	int16_t _rudder_zgyro; ///< Angular speed around Z axis (raw)
	int16_t _rudder_xmag; ///< X Magnetic field (raw)
	int16_t _rudder_ymag; ///< Y Magnetic field (raw)
	int16_t _rudder_zmag; ///< Z Magnetic field (raw)
	int16_t _stick_pot1; ///< Stick deflection pot 1 (raw)
	int16_t _stick_pot2; ///< Stick deflection pot 2 (raw)
	int16_t _rudder_pot; ///< Rudder deflection pot (raw)

	void update_string_pots();
	void update_imus();

};



#endif
