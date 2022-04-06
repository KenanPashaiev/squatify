import { StyleSheet, Text, View } from 'react-native';
import AppLoading from 'expo-app-loading';
import { useFonts } from 'expo-font';
import { NavigationContainer } from '@react-navigation/native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { iconSelectedColor, iconUnselectedColor } from './utils/colors';
import DatePage from './components/datePage/datePage';
import CalendarIcon from './components/navbar/calendarIcon';
import GalleryIcon from './components/navbar/galleryIcon';
import HomeIcon from './components/navbar/homeIcon';
import AccountIcon from './components/navbar/accountIcon';
import GalleryPage from './components/galleryPage/galleryPage';

function HomeScreen(props) {
  return (
    <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
      <Text>{props.text}</Text>
    </View>
  );
}

function GalleryScreen(props) {
  return (
    <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
      <Text>{props.text}</Text>
    </View>
  );
}

function AccountScreen(props) {
  return (
    <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
      <Text>{props.text}</Text>
    </View>
  );
}

const Tab = createBottomTabNavigator();

export default function App() {
  let [fontsLoaded] = useFonts({
    'Lufga-ExtraLight': require('./assets/fonts/Lufga-ExtraLight.ttf'),
    'Lufga-Light': require('./assets/fonts/Lufga-Light.ttf'),
    'Lufga-Regular': require('./assets/fonts/Lufga-Regular.ttf'),
    'Lufga-Bold': require('./assets/fonts/Lufga-Bold.ttf'),
    'Lufga-ExtraBold': require('./assets/fonts/Lufga-ExtraBold.ttf'),
  });

  if (!fontsLoaded) {
    return <AppLoading />;
  }

  return (
    <NavigationContainer>
      <Tab.Navigator
        initialRouteName="HomePage"
        screenOptions={
          ({ route }) => ({

            tabBarIcon: ({ focused, color, size }) => {
              if (route.name === 'HomePage') {
                return <HomeIcon focused={focused}></HomeIcon>;
              }

              if (route.name === 'GalleryPage') {
                return <GalleryIcon focused={focused}></GalleryIcon>;
              }

              if (route.name === 'DatePage') {
                return <CalendarIcon focused={focused}></CalendarIcon>;
              }

              if (route.name === 'AccountPage') {
                return <AccountIcon focused={focused}></AccountIcon>;
              }
            },
            headerShown: false,
            tabBarShowLabel: false,
        
            tabBarActiveTintColor: iconSelectedColor,
            tabBarInactiveTintColor: iconUnselectedColor,
          })}
      >
        <Tab.Screen name="HomePage" component={HomeScreen} />
        <Tab.Screen name="DatePage" component={DatePage} options={{ title: 'Date Page' }} />
        <Tab.Screen name="GalleryPage" component={GalleryPage} />
        <Tab.Screen name="AccountPage" component={AccountScreen} />
      </Tab.Navigator>
    </NavigationContainer >
  );
}

const styles = StyleSheet.create({
  container: {
  },
});