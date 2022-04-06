import { View } from 'react-native';
import CalendarIconSvg from '../../assets/calendarIcon';
import { iconSelectedColor, iconUnselectedColor } from '../../utils/colors';
import { vh } from '../../utils/units';

export default function CalendarIcon(props) {
  return (
    <View>
      <CalendarIconSvg width={3.5*vh} height={3.5*vh} fill={props.focused?iconSelectedColor:iconUnselectedColor}></CalendarIconSvg>
    </View>
  );
}