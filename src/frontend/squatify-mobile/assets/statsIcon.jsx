import * as React from "react"
import Svg, { Path } from "react-native-svg"
/* SVGR has dropped some elements not supported by react-native-svg: title */

const StatsIcon = (props) => (
  <Svg width={21} height={20} xmlns="http://www.w3.org/2000/svg" fillRule="evenodd" {...props}>
    <Path
      d="M18.9 17c0 .552-.47 1-1.05 1-.58 0-1.05-.448-1.05-1V3c0-.552.47-1 1.05-1 .58 0 1.05.448 1.05 1v14Zm0-17h-2.1c-1.16 0-2.1.895-2.1 2v16c0 1.105.94 2 2.1 2h2.1c1.16 0 2.1-.895 2.1-2V2c0-1.105-.94-2-2.1-2ZM4.2 17c0 .552-.47 1-1.05 1-.58 0-1.05-.448-1.05-1V7c0-.552.47-1 1.05-1 .58 0 1.05.448 1.05 1v10Zm0-13H2.1C.94 4 0 4.895 0 6v12c0 1.105.94 2 2.1 2h2.1c1.16 0 2.1-.895 2.1-2V6c0-1.105-.94-2-2.1-2Zm7.35 13c0 .552-.47 1-1.05 1-.58 0-1.05-.448-1.05-1v-4c0-.552.47-1 1.05-1 .58 0 1.05.448 1.05 1v4Zm0-7h-2.1c-1.16 0-2.1.895-2.1 2v6c0 1.105.94 2 2.1 2h2.1c1.16 0 2.1-.895 2.1-2v-6c0-1.105-.94-2-2.1-2Z"
      fillRule="evenodd"
    />
  </Svg>
)

export default StatsIcon
