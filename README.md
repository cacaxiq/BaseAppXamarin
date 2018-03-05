## FontAwesome examples

      <!-- Business as usual -->
			<Label Text="Just Normal Text" />

			<!-- A Map marker using a single character -->
			<Label Text="&#xf041;"
			       FontSize="40" FontFamily="FontAwesome" />

			<!-- Using a resource -->
			<Label Text="{x:Static local:FontAwesome.FAPhone}" 
				   FontSize="40" FontFamily="FontAwesome"  />

			<!-- The FontFamily reference is for iOS. On android
				it will be ignored, hence the need of a custom renderer -->

			<Button Text="&#xf041;" FontSize="40" FontFamily="FontAwesome" />
