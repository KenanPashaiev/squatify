import { StyleSheet, Text, View, Image, ActivityIndicator } from 'react-native';
import { accentBackgroundColor, forgroundColor, backgroundColor, accentFontColor, defaultInvertFontColor, secondaryInvertFontColor } from '../../../utils/colors';
import { vh } from '../../../utils/units';

export default function VideoCell(props) {
  const loading = <ActivityIndicator size="large" color={accentBackgroundColor} hidesWhenStopped={true} animating={props.video == null} />;

  const preview = (
    <View style={styles.previewContainer}>
      <Image
        style={styles.preview}
        source={{
          uri: props.video.previewLink
        }}
      />
      <Text style={styles.type}>Deadlift</Text>
      <Text style={styles.videoName}>{props.video.name}</Text>
      <Text style={styles.postedDate}>{props.video.postedDate}</Text>
      <Text style={styles.duration}>{props.video.duration}</Text>
    </View>
  );

  return (
    <View style={styles.video}>
      {props.video == null ? loading : preview}
    </View>
  );
}

const styles = StyleSheet.create({
  video: {
    flex: 1/3,
    height: 25*vh,
    margin: 0.1*vh,

    backgroundColor: forgroundColor,
    borderRadius: 1 * vh,
  },
  previewContainer: {
    flex: 1,
    backgroundColor: 'black',
    borderRadius: 0.7 * vh,
  },
  preview: {
    flex: 1,
    borderRadius: 0.7 * vh,
    resizeMode: 'cover',
    opacity: 0.7,
  },
  videoName: {
    padding: 1 * vh,
    position: 'absolute',
    bottom: 0,

    fontSize: 1.5 * vh,
    fontFamily: "Lufga-Bold",
    color: defaultInvertFontColor,
  },
  postedDate: {
    padding: 1 * vh,
    position: 'absolute',
    bottom: 0,
    right: 0,
    opacity: 0.75,

    fontSize: 1.2 * vh,
    fontFamily: "Lufga-Regular",
    color: secondaryInvertFontColor,
  },
  type: {
    padding: 1 * vh,
    paddingBottom: 3 * vh,
    position: 'absolute',
    bottom: 0,

    fontSize: 1.5 * vh,
    fontFamily: "Lufga-Regular",
    color: accentFontColor,
    opacity: 0.9,
  }
  ,
  duration: {
    padding: 1 * vh,
    position: 'absolute',
    top: 0,
    right: 0,

    fontSize: 1.5 * vh,
    fontFamily: "Lufga-Regular",
    color: defaultInvertFontColor,
    opacity: 0.9,
  }
});

