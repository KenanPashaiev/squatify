import { StyleSheet, View } from 'react-native';
import TitlePanel from './titlePanel/titlePanel';
import VideoPanel from './videoPanel/videoPanel';

export default function GalleryPage() {
  return (
    <View style={styles.container}>
      <TitlePanel></TitlePanel>
      <VideoPanel></VideoPanel>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 14,
    flexDirection: 'column',
  },
});
