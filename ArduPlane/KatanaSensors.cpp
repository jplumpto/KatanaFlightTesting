#include "KatanaSensors.h"

KatanaSensors::KatanaSensors()
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

}
	
bool KatanaSensors::update()
{
	return false;
}