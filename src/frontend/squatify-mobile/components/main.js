import { StyleSheet, View } from 'react-native';
import DatePage from './datePage/datePage';

export default function Main() {
  return (
    <View style={styles.container}>
      <DatePage></DatePage>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 14,
    flexDirection: 'column',
  },
});
