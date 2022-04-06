import { StyleSheet, View } from 'react-native';
import RoutinePanel from './routinePanel/routinePanel';
import DayPanel from './dayPanel/dayPanel';

export default function DatePage() {
  return (
    <View style={styles.container}>
      <DayPanel></DayPanel>
      <RoutinePanel></RoutinePanel>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 14,
    flexDirection: 'column',
  },
});
