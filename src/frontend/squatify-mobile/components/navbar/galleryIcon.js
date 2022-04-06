import { StyleSheet, View } from 'react-native';
import GalleryIconSvg from '../../assets/galleryIcon';
import { iconSelectedColor, iconUnselectedColor } from '../../utils/colors';
import { vh } from '../../utils/units';

export default function GalleryIcon(props) {
  return (
    <View>
      <GalleryIconSvg width={3.5*vh} height={3.5*vh} fill={props.focused?iconSelectedColor:iconUnselectedColor}></GalleryIconSvg>
    </View>
  );
}