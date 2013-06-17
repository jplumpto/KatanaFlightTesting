// MESSAGE RAW_KATANA PACKING

#define MAVLINK_MSG_ID_RAW_KATANA 65

typedef struct __mavlink_raw_katana_t
{
	uint32_t time_boot_ms; ///< Timestamp (milliseconds since system boot)
	int16_t stick_xacc; ///< X acceleration (raw)
	int16_t stick_yacc; ///< Y acceleration (raw)
	int16_t stick_zacc; ///< Z acceleration (raw)
	int16_t stick_xgyro; ///< Angular speed around X axis (raw)
	int16_t stick_ygyro; ///< Angular speed around Y axis (raw)
	int16_t stick_zgyro; ///< Angular speed around Z axis (raw)
	int16_t stick_xmag; ///< X Magnetic field (raw)
	int16_t stick_ymag; ///< Y Magnetic field (raw)
	int16_t stick_zmag; ///< Z Magnetic field (raw)
	int16_t rudder_xacc; ///< X acceleration (raw)
	int16_t rudder_yacc; ///< Y acceleration (raw)
	int16_t rudder_zacc; ///< Z acceleration (raw)
	int16_t rudder_xgyro; ///< Angular speed around X axis (raw)
	int16_t rudder_ygyro; ///< Angular speed around Y axis (raw)
	int16_t rudder_zgyro; ///< Angular speed around Z axis (raw)
	int16_t rudder_xmag; ///< X Magnetic field (raw)
	int16_t rudder_ymag; ///< Y Magnetic field (raw)
	int16_t rudder_zmag; ///< Z Magnetic field (raw)
	int16_t stick_pot1; ///< Stick deflection pot 1 (raw)
	int16_t stick_pot2; ///< Stick deflection pot 2 (raw)
	int16_t rudder_pot; ///< Rudder deflection pot (raw)
} mavlink_raw_katana_t;

#define MAVLINK_MSG_ID_RAW_KATANA_LEN 46
#define MAVLINK_MSG_ID_65_LEN 46



#define MAVLINK_MESSAGE_INFO_RAW_KATANA { \
	"RAW_KATANA", \
	22, \
	{  { "time_boot_ms", NULL, MAVLINK_TYPE_UINT32_T, 0, 0, offsetof(mavlink_raw_katana_t, time_boot_ms) }, \
         { "stick_xacc", NULL, MAVLINK_TYPE_INT16_T, 0, 4, offsetof(mavlink_raw_katana_t, stick_xacc) }, \
		 { "stick_yacc", NULL, MAVLINK_TYPE_INT16_T, 0, 6, offsetof(mavlink_raw_katana_t, stick_yacc) }, \
		 { "stick_zacc", NULL, MAVLINK_TYPE_INT16_T, 0, 8, offsetof(mavlink_raw_katana_t, stick_zacc) }, \
		 { "stick_xgyro", NULL, MAVLINK_TYPE_INT16_T, 0, 10, offsetof(mavlink_raw_katana_t, stick_xgyro) }, \
		 { "stick_ygyro", NULL, MAVLINK_TYPE_INT16_T, 0, 12, offsetof(mavlink_raw_katana_t, stick_ygyro) }, \
		 { "stick_zgyro", NULL, MAVLINK_TYPE_INT16_T, 0, 14, offsetof(mavlink_raw_katana_t, stick_zgyro) }, \
		 { "stick_xmag", NULL, MAVLINK_TYPE_INT16_T, 0, 16, offsetof(mavlink_raw_katana_t, stick_xmag) }, \
		 { "stick_ymag", NULL, MAVLINK_TYPE_INT16_T, 0, 18, offsetof(mavlink_raw_katana_t, stick_ymag) }, \
		 { "stick_zmag", NULL, MAVLINK_TYPE_INT16_T, 0, 20, offsetof(mavlink_raw_katana_t, stick_zmag) }, \
		 { "rudder_xacc", NULL, MAVLINK_TYPE_INT16_T, 0, 22, offsetof(mavlink_raw_katana_t, rudder_xacc) }, \
		 { "rudder_yacc", NULL, MAVLINK_TYPE_INT16_T, 0, 24, offsetof(mavlink_raw_katana_t, rudder_yacc) }, \
		 { "rudder_zacc", NULL, MAVLINK_TYPE_INT16_T, 0, 26, offsetof(mavlink_raw_katana_t, rudder_zacc) }, \
		 { "rudder_xgyro", NULL, MAVLINK_TYPE_INT16_T, 0, 28, offsetof(mavlink_raw_katana_t, rudder_xgyro) }, \
		 { "rudder_ygyro", NULL, MAVLINK_TYPE_INT16_T, 0, 30, offsetof(mavlink_raw_katana_t, rudder_ygyro) }, \
		 { "rudder_zgyro", NULL, MAVLINK_TYPE_INT16_T, 0, 32, offsetof(mavlink_raw_katana_t, rudder_zgyro) }, \
		 { "rudder_xmag", NULL, MAVLINK_TYPE_INT16_T, 0, 34, offsetof(mavlink_raw_katana_t, rudder_xmag) }, \
		 { "rudder_ymag", NULL, MAVLINK_TYPE_INT16_T, 0, 36, offsetof(mavlink_raw_katana_t, rudder_ymag) }, \
		 { "rudder_zmag", NULL, MAVLINK_TYPE_INT16_T, 0, 38, offsetof(mavlink_raw_katana_t, rudder_zmag) }, \
         { "stick_pot1", NULL, MAVLINK_TYPE_INT16_T, 0, 40, offsetof(mavlink_raw_katana_t, stick_pot1) }, \
         { "stick_pot2", NULL, MAVLINK_TYPE_INT16_T, 0, 42, offsetof(mavlink_raw_katana_t, stick_pot2) }, \
         { "rudder_pot", NULL, MAVLINK_TYPE_INT16_T, 0, 44, offsetof(mavlink_raw_katana_t, rudder_pot) }, \
         } \
}


/**
 * @brief Pack a raw_katana message
 * @param system_id ID of this system
 * @param component_id ID of this component (e.g. 200 for IMU)
 * @param msg The MAVLink message to compress the data into
 *
 * @return length of the message in bytes (excluding serial stream start sign)
 */
static inline uint16_t mavlink_msg_raw_katana_pack(uint8_t system_id, uint8_t component_id, mavlink_message_t* msg,
						       uint32_t time_boot_ms,int16_t stick_xacc,int16_t stick_yacc,int16_t stick_zacc,
							  int16_t stick_xgyro,int16_t stick_ygyro,int16_t stick_zgyro,int16_t stick_xmag,
							  int16_t stick_ymag,int16_t stick_zmag,int16_t rudder_xacc,int16_t rudder_yacc,
							  int16_t rudder_zacc,int16_t rudder_xgyro,int16_t rudder_ygyro,int16_t rudder_zgyro,
							  int16_t rudder_xmag,int16_t rudder_ymag,int16_t rudder_zmag,int16_t stick_pot1,
							  int16_t stick_pot2,int16_t rudder_pot)
{
#if MAVLINK_NEED_BYTE_SWAP || !MAVLINK_ALIGNED_FIELDS
	char buf[28];
	_mav_put_uint32_t(buf, 0, time_boot_ms);
	_mav_put_int16_t(buf,	4	,	stick_xacc	);
	_mav_put_int16_t(buf,	6	,	stick_yacc	);
	_mav_put_int16_t(buf,	8	,	stick_zacc	);
	_mav_put_int16_t(buf,	10	,	stick_xgyro	);
	_mav_put_int16_t(buf,	12	,	stick_ygyro	);
	_mav_put_int16_t(buf,	14	,	stick_zgyro	);
	_mav_put_int16_t(buf,	16	,	stick_xmag	);
	_mav_put_int16_t(buf,	18	,	stick_ymag	);
	_mav_put_int16_t(buf,	20	,	stick_zmag	);
	_mav_put_int16_t(buf,	22	,	rudder_xacc	);
	_mav_put_int16_t(buf,	24	,	rudder_yacc	);
	_mav_put_int16_t(buf,	26	,	rudder_zacc	);
	_mav_put_int16_t(buf,	28	,	rudder_xgyro );
	_mav_put_int16_t(buf,	30	,	rudder_ygyro );
	_mav_put_int16_t(buf,	32	,	rudder_zgyro );
	_mav_put_int16_t(buf,	34	,	rudder_xmag	);
	_mav_put_int16_t(buf,	36	,	rudder_ymag	);
	_mav_put_int16_t(buf,	38	,	rudder_zmag	);
	_mav_put_int16_t(buf,	40	,	stick_pot1	);
	_mav_put_int16_t(buf,	42	,	stick_pot2	);
	_mav_put_int16_t(buf,	44	,	rudder_pot	);

        memcpy(_MAV_PAYLOAD_NON_CONST(msg), buf, 46);
#else
	mavlink_raw_katana_t packet;
	packet.time_boot_ms = time_boot_ms;
	packet.stick_xacc = stick_xacc;
	packet.stick_yacc = stick_yacc;
	packet.stick_zacc = stick_zacc;
	packet.stick_xgyro = stick_xgyro;
	packet.stick_ygyro = stick_ygyro;
	packet.stick_zgyro = stick_zgyro;
	packet.stick_xmag = stick_xmag;
	packet.stick_ymag = stick_ymag;
	packet.stick_zmag = stick_zmag;

	packet.rudder_xacc = rudder_xacc;
	packet.rudder_yacc = rudder_yacc;
	packet.rudder_zacc = rudder_zacc;
	packet.rudder_xgyro = rudder_xgyro;
	packet.rudder_ygyro = rudder_ygyro;
	packet.rudder_zgyro = rudder_zgyro;
	packet.rudder_xmag = rudder_xmag;
	packet.rudder_ymag = rudder_ymag;
	packet.rudder_zmag = rudder_zmag;

	packet.stick_pot1 = stick_pot1;
	packet.stick_pot2 = stick_pot2;
	packet.rudder_pot = rudder_pot;

        memcpy(_MAV_PAYLOAD_NON_CONST(msg), &packet, 46);
#endif

	msg->msgid = MAVLINK_MSG_ID_RAW_KATANA;
	return mavlink_finalize_message(msg, system_id, component_id, 46, 39);
}

/**
 * @brief Pack a raw_katana message on a channel
 * @param system_id ID of this system
 * @param component_id ID of this component (e.g. 200 for IMU)
 * @param chan The MAVLink channel this message was sent over
 * @param msg The MAVLink message to compress the data into
 * @param time_boot_ms Timestamp (milliseconds since system boot)
 * @param roll Roll angle (rad, -pi..+pi)
 * @param pitch Pitch angle (rad, -pi..+pi)
 * @param yaw Yaw angle (rad, -pi..+pi)
 * @param rollspeed Roll angular speed (rad/s)
 * @param pitchspeed Pitch angular speed (rad/s)
 * @param yawspeed Yaw angular speed (rad/s)
 * @return length of the message in bytes (excluding serial stream start sign)
 */
static inline uint16_t mavlink_msg_raw_katana_pack_chan(uint8_t system_id, uint8_t component_id, uint8_t chan,
							   mavlink_message_t* msg,
						       uint32_t time_boot_ms,int16_t stick_xacc,int16_t stick_yacc,int16_t stick_zacc,
							  int16_t stick_xgyro,int16_t stick_ygyro,int16_t stick_zgyro,int16_t stick_xmag,
							  int16_t stick_ymag,int16_t stick_zmag,int16_t rudder_xacc,int16_t rudder_yacc,
							  int16_t rudder_zacc,int16_t rudder_xgyro,int16_t rudder_ygyro,int16_t rudder_zgyro,
							  int16_t rudder_xmag,int16_t rudder_ymag,int16_t rudder_zmag,int16_t stick_pot1,
							  int16_t stick_pot2,int16_t rudder_pot)
{
#if MAVLINK_NEED_BYTE_SWAP || !MAVLINK_ALIGNED_FIELDS
	char buf[28];
	_mav_put_uint32_t(buf, 0, time_boot_ms);
	_mav_put_int16_t(buf,	4	,	stick_xacc	);
	_mav_put_int16_t(buf,	6	,	stick_yacc	);
	_mav_put_int16_t(buf,	8	,	stick_zacc	);
	_mav_put_int16_t(buf,	10	,	stick_xgyro	);
	_mav_put_int16_t(buf,	12	,	stick_ygyro	);
	_mav_put_int16_t(buf,	14	,	stick_zgyro	);
	_mav_put_int16_t(buf,	16	,	stick_xmag	);
	_mav_put_int16_t(buf,	18	,	stick_ymag	);
	_mav_put_int16_t(buf,	20	,	stick_zmag	);
	_mav_put_int16_t(buf,	22	,	rudder_xacc	);
	_mav_put_int16_t(buf,	24	,	rudder_yacc	);
	_mav_put_int16_t(buf,	26	,	rudder_zacc	);
	_mav_put_int16_t(buf,	28	,	rudder_xgyro );
	_mav_put_int16_t(buf,	30	,	rudder_ygyro );
	_mav_put_int16_t(buf,	32	,	rudder_zgyro );
	_mav_put_int16_t(buf,	34	,	rudder_xmag	);
	_mav_put_int16_t(buf,	36	,	rudder_ymag	);
	_mav_put_int16_t(buf,	38	,	rudder_zmag	);
	_mav_put_int16_t(buf,	40	,	stick_pot1	);
	_mav_put_int16_t(buf,	42	,	stick_pot2	);
	_mav_put_int16_t(buf,	44	,	rudder_pot	);

        memcpy(_MAV_PAYLOAD_NON_CONST(msg), buf, 46);
#else
	mavlink_raw_katana_t packet;
	packet.time_boot_ms = time_boot_ms;
	packet.stick_xacc = stick_xacc;
	packet.stick_yacc = stick_yacc;
	packet.stick_zacc = stick_zacc;
	packet.stick_xgyro = stick_xgyro;
	packet.stick_ygyro = stick_ygyro;
	packet.stick_zgyro = stick_zgyro;
	packet.stick_xmag = stick_xmag;
	packet.stick_ymag = stick_ymag;
	packet.stick_zmag = stick_zmag;

	packet.rudder_xacc = rudder_xacc;
	packet.rudder_yacc = rudder_yacc;
	packet.rudder_zacc = rudder_zacc;
	packet.rudder_xgyro = rudder_xgyro;
	packet.rudder_ygyro = rudder_ygyro;
	packet.rudder_zgyro = rudder_zgyro;
	packet.rudder_xmag = rudder_xmag;
	packet.rudder_ymag = rudder_ymag;
	packet.rudder_zmag = rudder_zmag;

	packet.stick_pot1 = stick_pot1;
	packet.stick_pot2 = stick_pot2;
	packet.rudder_pot = rudder_pot;

        memcpy(_MAV_PAYLOAD_NON_CONST(msg), &packet, 46);
#endif

	msg->msgid = MAVLINK_MSG_ID_RAW_KATANA;
	return mavlink_finalize_message_chan(msg, system_id, component_id, chan, 46, 39);
}

/**
 * @brief Encode a raw_katana struct into a message
 *
 * @param system_id ID of this system
 * @param component_id ID of this component (e.g. 200 for IMU)
 * @param msg The MAVLink message to compress the data into
 * @param raw_katana C-struct to read the message contents from
 */
static inline uint16_t mavlink_msg_raw_katana_encode(uint8_t system_id, uint8_t component_id, mavlink_message_t* msg, const mavlink_raw_katana_t* raw_katana)
{
	return mavlink_msg_raw_katana_pack(system_id, component_id, msg, raw_katana->time_boot_ms, 
		raw_katana->stick_xacc, raw_katana->stick_yacc, raw_katana->stick_zacc, raw_katana->stick_xgyro, raw_katana->stick_ygyro,
		raw_katana->stick_zgyro, raw_katana->stick_xmag, raw_katana->stick_ymag, raw_katana->stick_zmag, raw_katana->rudder_xacc,
		raw_katana->rudder_yacc, raw_katana->rudder_zacc, raw_katana->rudder_xgyro, raw_katana->rudder_ygyro, raw_katana->rudder_zgyro,
		raw_katana->rudder_xmag, raw_katana->rudder_ymag, raw_katana->rudder_zmag, raw_katana->stick_pot1, raw_katana->stick_pot2, raw_katana->rudder_pot );
}

/**
 * @brief Send a raw_katana message
 * @param chan MAVLink channel to send the message
 *
 * @param time_boot_ms Timestamp (milliseconds since system boot)
 * @param roll Roll angle (rad, -pi..+pi)
 * @param pitch Pitch angle (rad, -pi..+pi)
 * @param yaw Yaw angle (rad, -pi..+pi)
 * @param rollspeed Roll angular speed (rad/s)
 * @param pitchspeed Pitch angular speed (rad/s)
 * @param yawspeed Yaw angular speed (rad/s)
 */
#ifdef MAVLINK_USE_CONVENIENCE_FUNCTIONS

static inline void mavlink_msg_raw_katana_send(mavlink_channel_t chan, 
											   uint32_t time_boot_ms,int16_t stick_xacc,int16_t stick_yacc,int16_t stick_zacc,
											  int16_t stick_xgyro,int16_t stick_ygyro,int16_t stick_zgyro,int16_t stick_xmag,
											  int16_t stick_ymag,int16_t stick_zmag,int16_t rudder_xacc,int16_t rudder_yacc,
											  int16_t rudder_zacc,int16_t rudder_xgyro,int16_t rudder_ygyro,int16_t rudder_zgyro,
											  int16_t rudder_xmag,int16_t rudder_ymag,int16_t rudder_zmag,int16_t stick_pot1,
											  int16_t stick_pot2,int16_t rudder_pot)
{
#if MAVLINK_NEED_BYTE_SWAP || !MAVLINK_ALIGNED_FIELDS
	char buf[28];
	_mav_put_uint32_t(buf, 0, time_boot_ms);
	_mav_put_int16_t(buf,	4	,	stick_xacc	);
	_mav_put_int16_t(buf,	6	,	stick_yacc	);
	_mav_put_int16_t(buf,	8	,	stick_zacc	);
	_mav_put_int16_t(buf,	10	,	stick_xgyro	);
	_mav_put_int16_t(buf,	12	,	stick_ygyro	);
	_mav_put_int16_t(buf,	14	,	stick_zgyro	);
	_mav_put_int16_t(buf,	16	,	stick_xmag	);
	_mav_put_int16_t(buf,	18	,	stick_ymag	);
	_mav_put_int16_t(buf,	20	,	stick_zmag	);
	_mav_put_int16_t(buf,	22	,	rudder_xacc	);
	_mav_put_int16_t(buf,	24	,	rudder_yacc	);
	_mav_put_int16_t(buf,	26	,	rudder_zacc	);
	_mav_put_int16_t(buf,	28	,	rudder_xgyro );
	_mav_put_int16_t(buf,	30	,	rudder_ygyro );
	_mav_put_int16_t(buf,	32	,	rudder_zgyro );
	_mav_put_int16_t(buf,	34	,	rudder_xmag	);
	_mav_put_int16_t(buf,	36	,	rudder_ymag	);
	_mav_put_int16_t(buf,	38	,	rudder_zmag	);
	_mav_put_int16_t(buf,	40	,	stick_pot1	);
	_mav_put_int16_t(buf,	42	,	stick_pot2	);
	_mav_put_int16_t(buf,	44	,	rudder_pot	);

	_mav_finalize_message_chan_send(chan, MAVLINK_MSG_ID_RAW_KATANA, buf, 46, 39);
#else
	mavlink_raw_katana_t packet;
	packet.time_boot_ms = time_boot_ms;
	packet.stick_xacc = stick_xacc;
	packet.stick_yacc = stick_yacc;
	packet.stick_zacc = stick_zacc;
	packet.stick_xgyro = stick_xgyro;
	packet.stick_ygyro = stick_ygyro;
	packet.stick_zgyro = stick_zgyro;
	packet.stick_xmag = stick_xmag;
	packet.stick_ymag = stick_ymag;
	packet.stick_zmag = stick_zmag;

	packet.rudder_xacc = rudder_xacc;
	packet.rudder_yacc = rudder_yacc;
	packet.rudder_zacc = rudder_zacc;
	packet.rudder_xgyro = rudder_xgyro;
	packet.rudder_ygyro = rudder_ygyro;
	packet.rudder_zgyro = rudder_zgyro;
	packet.rudder_xmag = rudder_xmag;
	packet.rudder_ymag = rudder_ymag;
	packet.rudder_zmag = rudder_zmag;

	packet.stick_pot1 = stick_pot1;
	packet.stick_pot2 = stick_pot2;
	packet.rudder_pot = rudder_pot;

	_mav_finalize_message_chan_send(chan, MAVLINK_MSG_ID_RAW_KATANA, (const char *)&packet, 46, 39);
#endif
}

#endif

// MESSAGE RAW_KATANA UNPACKING


///**
// * @brief Get field time_boot_ms from raw_katana message
// *
// * @return Timestamp (milliseconds since system boot)
// */
//static inline uint32_t mavlink_msg_raw_katana_get_time_boot_ms(const mavlink_message_t* msg)
//{
//	return _MAV_RETURN_uint32_t(msg,  0);
//}
//
///**
// * @brief Get field roll from raw_katana message
// *
// * @return Roll angle (rad, -pi..+pi)
// */
//static inline float mavlink_msg_raw_katana_get_roll(const mavlink_message_t* msg)
//{
//	return _MAV_RETURN_float(msg,  4);
//}
//
///**
// * @brief Get field pitch from raw_katana message
// *
// * @return Pitch angle (rad, -pi..+pi)
// */
//static inline float mavlink_msg_raw_katana_get_pitch(const mavlink_message_t* msg)
//{
//	return _MAV_RETURN_float(msg,  8);
//}
//
///**
// * @brief Get field yaw from raw_katana message
// *
// * @return Yaw angle (rad, -pi..+pi)
// */
//static inline float mavlink_msg_raw_katana_get_yaw(const mavlink_message_t* msg)
//{
//	return _MAV_RETURN_float(msg,  12);
//}
//
///**
// * @brief Get field rollspeed from raw_katana message
// *
// * @return Roll angular speed (rad/s)
// */
//static inline float mavlink_msg_raw_katana_get_rollspeed(const mavlink_message_t* msg)
//{
//	return _MAV_RETURN_float(msg,  16);
//}
//
///**
// * @brief Get field pitchspeed from raw_katana message
// *
// * @return Pitch angular speed (rad/s)
// */
//static inline float mavlink_msg_raw_katana_get_pitchspeed(const mavlink_message_t* msg)
//{
//	return _MAV_RETURN_float(msg,  20);
//}
//
///**
// * @brief Get field yawspeed from raw_katana message
// *
// * @return Yaw angular speed (rad/s)
// */
//static inline float mavlink_msg_raw_katana_get_yawspeed(const mavlink_message_t* msg)
//{
//	return _MAV_RETURN_float(msg,  24);
//}
//
///**
// * @brief Decode a raw_katana message into a struct
// *
// * @param msg The message to decode
// * @param raw_katana C-struct to decode the message contents into
// */
//static inline void mavlink_msg_raw_katana_decode(const mavlink_message_t* msg, mavlink_raw_katana_t* raw_katana)
//{
//#if MAVLINK_NEED_BYTE_SWAP
//	raw_katana->time_boot_ms = mavlink_msg_raw_katana_get_time_boot_ms(msg);
//	raw_katana->roll = mavlink_msg_raw_katana_get_roll(msg);
//	raw_katana->pitch = mavlink_msg_raw_katana_get_pitch(msg);
//	raw_katana->yaw = mavlink_msg_raw_katana_get_yaw(msg);
//	raw_katana->rollspeed = mavlink_msg_raw_katana_get_rollspeed(msg);
//	raw_katana->pitchspeed = mavlink_msg_raw_katana_get_pitchspeed(msg);
//	raw_katana->yawspeed = mavlink_msg_raw_katana_get_yawspeed(msg);
//#else
//	memcpy(raw_katana, _MAV_PAYLOAD(msg), 28);
//#endif
//}
