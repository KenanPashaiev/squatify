import Svg, { Path } from "react-native-svg"

const HomeIconSvg = (props) => (
  <Svg
    xmlns="http://www.w3.org/2000/svg"
    viewBox="0 0 24 24"
    fill='none'
    width={20} height={20}
    {...props}
  >
    <Path d="m21.8 6.78-8.12-5.29a3.1 3.1 0 0 0-3.36 0L2.2 6.78A2.46 2.46 0 0 0 1 8.84V23h9v-5.57h4V23h9V8.84a2.46 2.46 0 0 0-1.2-2.06ZM21 21h-5v-5.57H8V21H3V8.84a.49.49 0 0 1 .26-.39l8.12-5.29a1.14 1.14 0 0 1 1.18 0l8.12 5.29a.49.49 0 0 1 .26.39Z" />
  </Svg>
)

export default HomeIconSvg;
