import { View } from 'react-native';
import HomeIconSvg from '../../assets/homeIcon';
import { iconSelectedColor, iconUnselectedColor } from '../../utils/colors';
import { vh } from '../../utils/units';

export default function HomeIcon(props) {
  return (
    <View>
      <HomeIconSvg width={3.5*vh} height={3.5*vh} fill={props.focused?iconSelectedColor:iconUnselectedColor}></HomeIconSvg>
    </View>
  );
}
