import { View } from 'react-native';
import ChecklistIconSvg from '../../assets/checklistIcon';
import { iconSelectedColor, iconUnselectedColor } from '../../utils/colors';
import { vh } from '../../utils/units';

export default function CheckListIcon(props) {
  return (
    <View style={styles.button}>
      <ChecklistIconSvg width={3.5*vh} height={3.5*vh} fill={props.focused?iconSelectedColor:iconUnselectedColor}></ChecklistIconSvg>
    </View>
  );
}
