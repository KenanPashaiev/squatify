import * as React from "react"
import Svg, { G, Path, Defs, ClipPath } from "react-native-svg"

const DumbellIcon = (props) => (
  <Svg
    width={48}
    height={48}
    fill="none"
    xmlns="http://www.w3.org/2000/svg"
    {...props}
  >
    <G clipPath="url(#a)">
      <Path
        d="M45 20h-1v-2a3 3 0 0 0-3-3h-2v-2a3 3 0 0 0-3-3h-3a3 3 0 0 0-3 3v7H18v-7a3 3 0 0 0-3-3h-3a3 3 0 0 0-3 3v2H7a3 3 0 0 0-3 3v2H3a3 3 0 0 0-3 3v2a3 3 0 0 0 3 3h1v2a3 3 0 0 0 3 3h2v2a3 3 0 0 0 3 3h3a3 3 0 0 0 3-3v-7h12v7a3 3 0 0 0 3 3h3a3 3 0 0 0 3-3v-2h2a3 3 0 0 0 3-3v-2h1a3 3 0 0 0 3-3v-2a3 3 0 0 0-3-3ZM3 26a1 1 0 0 1-1-1v-2a1 1 0 0 1 1-1h1v4H3Zm4 5a1 1 0 0 1-1-1V18a1 1 0 0 1 1-1h2v14H7Zm9 4a1 1 0 0 1-1 1h-3a1 1 0 0 1-1-1V13a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v22Zm2-9v-4h12v4H18Zm19 9a1 1 0 0 1-1 1h-3a1 1 0 0 1-1-1V13a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v22Zm5-5a1 1 0 0 1-1 1h-2V17h2a1 1 0 0 1 1 1v12Zm4-5a1 1 0 0 1-1 1h-1v-4h1a1 1 0 0 1 1 1v2Z"
        fill="#000"
      />
    </G>
    <Defs>
      <ClipPath id="a">
        <Path fill="#fff" d="M0 0h48v48H0z" />
      </ClipPath>
    </Defs>
  </Svg>
)

export default DumbellIcon
